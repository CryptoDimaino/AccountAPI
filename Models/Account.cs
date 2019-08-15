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
        public int AccountId {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
        public int? EmailAccountId {get;set;}
        public EmailAccount EmailAccount {get;set;}
        public int? PlatformId {get;set;}
        public Platform Platform {get;set;}

        // Keeps track of Accounts
        public Boolean Status {get;set;} // True = active, false = not active // Dont know password?

        // Event
        public int? EventId {get;set;}
        public Event Event {get;set;}
        public ICollection<Code> Codes {get;set;}// = new List<Code>();

    }
}