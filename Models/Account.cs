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
        public string Email {get;set;}
        [Required]
        public string EmailPassword {get;set;}
        [Required]
        public bool CheckedOutStatus {get;set;}
        [Required]
        public string EventLocation {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}
        public List<Game> Games {get;set;}
        public List<ControllerType> ControllerType {get;set;}
        public List<Platform> Platforms {get;set;}
    }
}