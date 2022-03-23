using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    
    public class Twit
    {
        [Key]
        public int Id { get; set; }
        public string TheTwit { get; set; }
        public int UserId { get; set; }
        

    }
    public class DaTwit
    {
        [Key]
        public int Id { get; set; }
        public string TheTwit { get; set; }
        public string UserId { get; set; }


    }

    public class ToSubscribe
    {
        [Key]
        public int Id { get; set; }
        public int TheUser { get; set; }
        public string UserToFollow { get; set; }
    }
    public class ToFollow
    {
        [Key]
        public int Id { get; set; }
        public string TheUser { get; set; }
        public string UserToFollow { get; set; }
    }
    public class FirstName
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        
    }



    public class UserAndTwit
    {
        public IdentityUser primoNameVm { get; set; }

        public DaTwit daTwitVm { get; set; }
        public ToFollow toSubscribeVm { get; set ; }
       
    }


}
