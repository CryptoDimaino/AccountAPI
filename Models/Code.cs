using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class Code
    {
        [Key]
        public int CodeId {get;set;}
        [Required]
        public string CodeString {get;set;}
        [Required]
        public bool UsedStatus {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Sets accounts through composite key
        public int? EmailAccountId {get;set;}
        public int? PlatformId {get;set;}
        public Account Account {get;set;}

        // Sets Game though foreign key
        [Required]
        public int GameId {get;set;}
        public Game Game {get;set;}
    }
}