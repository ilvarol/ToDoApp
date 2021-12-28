﻿using System;

namespace ToDoApp.API.DTOs.ToDoList
{
    public class ToDoListRead
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string userId { get; set; }
    }
}