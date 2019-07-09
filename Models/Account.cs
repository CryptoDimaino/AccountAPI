using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class Account
    {
        [Key]
        public int AccountId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Password {get;set;}
        [Required]
        public bool CheckedOutStatus {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int AccountTypeId {get;set;}
        public AccountType AccountType {get;set;}

        public int? EventId {get;set;}
        public Event Event {get;set;}

        public int PlatformId {get;set;}
        public Platform Platform {get;set;}

        public ICollection<GameAccount> GameAccounts {get;} = new List<GameAccount>();
        public virtual AccountProfile Profile {get;set;}
    }
}