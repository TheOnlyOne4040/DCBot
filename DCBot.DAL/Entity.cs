﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DCBot.DAL
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
