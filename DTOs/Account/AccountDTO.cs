using System;
using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.DTOs
{
    public class AccountDTO
    {
        public int AccountId {get;set;}
        public string Name {get;set;}
        public string Password {get;set;}
        public string PlatformName {get;set;}
        public IEnumerable<AccountGameDTO> GameAccounts {get;set;}
    }
}