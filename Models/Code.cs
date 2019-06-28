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
        // One to One for Games
        [Key]
        public int CodeId {get;set;}
        [Required]
        public string CodeString {get;set;}
        [Required]
        public string UsedStatus {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}
    }
}