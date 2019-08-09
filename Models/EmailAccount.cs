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
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public ICollection<Account> Accounts {get;} = new List<Account>();
    }
}