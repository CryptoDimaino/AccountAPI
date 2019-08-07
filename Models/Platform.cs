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
        public string URLToDocumentation {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public ICollection<Game> Games {get;} = new List<Game>();
        public ICollection<Account> Accounts {get;} = new List<Account>();
    }
}