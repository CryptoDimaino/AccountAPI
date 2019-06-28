using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class GamePlatform
    {
        [Key]
        public int GamePlatformId {get;set;}
        // [Required]
        // public string Name {get;set;}
        // [Required]
        // public bool ConnectionType {get;set;}
        // [Required]
        // public DateTime ReleaseDate {get;set;}
        // [Required]
        // public string URLToDocumentation {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}
        // public ICollection<Game> Games {get;set;}
        // Missing lists/ IDs
    }
}