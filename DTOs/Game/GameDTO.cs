using System;
using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.DTOs
{
    public class GameDTO
    {
        public int GameId {get;set;}
        public string GameTitle {get;set;}
        public string PlatformName {get;set;}
        public DateTime ReleaseDate {get;set;}
        public IEnumerable<GameAccountDTO> Accounts {get;set;} = new List<GameAccountDTO>();
    }

    public class GameAccountDTO
    {
        public string CodeString {get;set;}
        public int? AccountId {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
        public string Email {get;set;}
        public string EmailPassword {get;set;}
    }
}