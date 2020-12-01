﻿using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class KweetCreateDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
