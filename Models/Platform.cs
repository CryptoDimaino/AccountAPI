using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class Platform
    {
        [Key]
        public int PlatformId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}
    }
}