using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class GameControllerType
    {
        public int GameId {get;set;}
        public Game Game {get;set;}
        public int ControllerTypeId {get;set;}
        public ControllerType ControllerType {get;set;}
    }
}