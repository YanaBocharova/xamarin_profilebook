using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace App_Profile_Book.Model
{
    public class ProfileModel : IBaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique ]
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9]{4,8}$", ErrorMessage = "Login must have 4-8 symbs and start with a letter")]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*)\S{4,16}$", ErrorMessage = "Password must have 4-16 symbs and contain one uppercase,one lowercase letter , one number")]
        public string Password { get; set; }
        [Required]
        [Compare ("Password",ErrorMessage = "Password and Confirm password not equal")]
        public string ConfirmPassword { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
