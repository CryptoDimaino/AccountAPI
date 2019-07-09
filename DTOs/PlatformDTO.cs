using System;
using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.DTOs
{
    public class PlatformDTO
    {
        public int PlatformId {get;set;}
        public string Name {get;set;}
        public IEnumerable<PlatformGameDTO> Games {get;set;}// = new List<Game>();
    }
}