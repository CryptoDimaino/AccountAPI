using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class Rating
    {
        public enum RatingSystem
        {
            ESRB,
            PEGI,
            RARS,
            ACB,
            USK
        }

        public enum Country
        {
            USA,
            EU,
            Russia,
            Australia,
            Germany
        }

        [Key]
        public int RatingId {get;set;}
        [Required]
        public RatingSystem RatingsSystem {get;set;}
        [Required]
        public Country RatingsCountry {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public int Age {get;set;}
        [Required]
        public string Definition {get;set;}
        [Required]
        public string ImageLink {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public ICollection<GameRating> GameRatings {get;} = new List<GameRating>();
    }
}