// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Newtonsoft.Json;

// namespace AccountAPI.Models
// {
// 	public class AccountProfile
//     {
//         [Key]
//         public int AccountProfileId {get;set;}
//         [Required]
//         public string Name {get;set;}
//         [Required]
//         public DateTime Birthday {get;set;}
//         [Required]
//         public string PhoneNumber {get;set;}
//         [Required]
//         public string Address {get;set;}
//         [Required]
//         public string SecretQuestion1 {get;set;}
//         [Required]
//         public string SecretQuestion2 {get;set;}
//         [Required]
//         public string SecretQuestion3 {get;set;}
//         [Required]
//         public string SecretAnswer1 {get;set;}
//         [Required]
//         public string SecretAnswer2 {get;set;}
//         [Required]
//         public string SecretAnswer3 {get;set;}
//         [Required]
//         public DateTime CreatedAt {get;set;}
//         [Required]
//         public DateTime UpdatedAt {get;set;}
//         public List<Account> Accounts {get;set;}
//     }
// }