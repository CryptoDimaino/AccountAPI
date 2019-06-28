using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class GameAccount
    {
        public int GameId {get;set;}
        public Game Game {get;set;}
        public int AccountId {get;set;}
        public Account Account {get;set;}
    }
}