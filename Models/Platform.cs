using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class Platform
    {
        [Key]
        public int PlatformId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public ICollection<GamePlatform> GamePlatforms {get;} = new List<GamePlatform>();

        public int PlatformTypeId {get;set;}
        public PlatformType PlatformType {get;set;}
    }
}