using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApp.API.DTOs.ToDoItem;
using ToDoApp.API.DTOs.ToDoList;
using ToDoApp.API.DTOs.User;
using ToDoApp.API.Models;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTService _JWTService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IJWTService JWTService, IMapper mapper)
        {
            _userService = userService;
            _JWTService = JWTService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            var user = await _userService.GetUserByName(model.Username);
            if (user != null && _userService.CheckPassword(user, model.Password)) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var jwt = _JWTService.GenerateJSONWebToken(claims);

                return Ok(new {token = jwt});
            }

            return Unauthorized();
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(UserCreate model)
        {
            var userExists = await _userService.GetUserByName(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new  { Status = "Error", Message = "This user already exists!" });
            }

            await _userService.CreateUser(_mapper.Map<User>(model));

            return Ok(new ResponseObjectModel<User>
            {
                Success = true,
                StatusCode = 200,
                Message = "successful!",
                Response = null
            });
        }
    }
}