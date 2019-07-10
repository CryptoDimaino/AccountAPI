using System;
using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.DTOs
{
    public class AccountsDTO
    {
        public int AccountId {get;set;}
        public string Name {get;set;}
        public string Password {get;set;}
        public bool CheckedOutStatus {get;set;}
        public string PlatformName {get;set;}
        public string EventName {get;set;}
        public string AccountType {get;set;}
    }
}