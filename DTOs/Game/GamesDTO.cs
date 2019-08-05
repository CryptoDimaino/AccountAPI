using System;
using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.DTOs
{
    public class GamesDTO
    {
        public int GameId {get;set;}
        public string GameTitle {get;set;}
        public string PlatformName {get;set;}
        public int NumberOfAccounts {get;set;}
    }
}