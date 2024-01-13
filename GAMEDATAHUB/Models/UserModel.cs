using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserSalt { get; set; }
        public int HeroID { get; set; }
        public bool IsPremium { get; set; }
    }
}