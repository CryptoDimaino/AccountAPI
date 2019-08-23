using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccountAPI.Models
{
	public class AccountPlatform
    {
        public int EmailAccountId {get;set;}
        public int PlatformId {get;set;}
    }
}