using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class RatingType
    {
        [Key]
        public int RatingTypeId {get;set;}
        [Required]
        public string Type {get;set;}
        [Required]
        public string Country {get;set;}
        [Required]
        public string GameRatingURL {get;set;}
        [Required]
        public string Definitions {get;set;}
        [Required]
        public string ImageLink {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}
    }
}