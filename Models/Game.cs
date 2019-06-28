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
        [Required]
        public bool ConnectionType {get;set;}
        [Required]
        public DateTime ReleaseDate {get;set;}
        [Required]
        public string URLToDocumentation {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;


        public ICollection<Code> Codes {get;set;}
        public ICollection<GameControllerType> GameControllerTypes {get;} = new List<GameControllerType>();
        public ICollection<GamePlatform> GamePlatforms {get;} = new List<GamePlatform>();
        public ICollection<GameAccount> GameAccounts {get;} = new List<GameAccount>();
        public ICollection<GameRating> GameRatings {get;} = new List<GameRating>();
    }
}