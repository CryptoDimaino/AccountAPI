using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class ControllerType
    {
        // One to Many for Games
        [Key]
        public int ControllerTypeId {get;set;}
        [Required]
        public string Type {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}
        public List<Game> Games {get;set;}
    }
}