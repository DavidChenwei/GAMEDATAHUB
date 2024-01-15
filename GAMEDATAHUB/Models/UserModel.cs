using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GAMEDATAHUB.Repository;

namespace GAMEDATAHUB.Models
{
    public class UserModel
    {
        [UsernameValidation]
        public string UserName { get; set; }

        [PasswordValidation]
        public string UserPassword { get; set; }

        [EmailValidation]
        public string UserEmail { get; set; }

        public string HashedPassword { get; set; }

        public string UserSalt { get; set; }

        public int HeroID { get; set; }

        public bool IsPremium { get; set; }

        public bool IsLogin { get; set; }
    }
}