using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class Game
    {
        [Key]
        public int GameId {get;set;}
        [Required]
        public string Name {get;set;}

        public int rawgId {get;set;}
        public int ConnectionType {get;set;}
        public DateTime? ReleaseDate {get;set;}
		public string URLToDocumentation {get;set;}
        // [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        // [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public ICollection<Code> Codes {get;} = new List<Code>();
        public int PlatformId {get;set;}
        public Platform Platform {get;set;}

        public ICollection<GameRating> GameRatings {get;} = new List<GameRating>();

    }
}