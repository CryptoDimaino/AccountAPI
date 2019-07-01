using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class AccountProfile
    {
        [ForeignKey("Account")]
        public int AccountProfileId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime Birthday {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        public string SecretQuestion1 {get;set;}
        public string SecretQuestion2 {get;set;}
        public string SecretQuestion3 {get;set;}
        public string SecretAnswer1 {get;set;}
        public string SecretAnswer2 {get;set;}
        public string SecretAnswer3 {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public virtual Account Account {get;set;}
    }
}