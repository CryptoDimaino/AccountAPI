using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class EmailAccount
    {
        [Key]
        public int EmailAccountId {get;set;}
        [Required]
        public string Email {get;set;}
        [Required]
        public string EmailPassword {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Platforms
        public ICollection<Platform> Platforms {get;} = new List<Platform>();
    }
}