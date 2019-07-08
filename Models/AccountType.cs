using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class AccountType
    {
        [Key]
        public int AccountTypeId {get;set;}
        [Required]
        public string Type {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public ICollection<Account> Accounts {get;} = new List<Account>();
    }
}