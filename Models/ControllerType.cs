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
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public ICollection<GameControllerType> GameControllerTypes {get;} = new List<GameControllerType>();
    }
}