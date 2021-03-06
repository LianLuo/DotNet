﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularForDotnetCore.Models
{
    public class ApplicationUserModel : BaseModel
    {
        [Column(TypeName = "VARCHAR(32)")]
        [Required]
        public string UserName { get; set; }
        [Column(TypeName ="VARCHAR(64)")]
        public string FullName { get; set; }
        [Column(TypeName = "VARCHAR(128)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(512)")]
        [Required]
        public string Password { get; set; }

    }
}
