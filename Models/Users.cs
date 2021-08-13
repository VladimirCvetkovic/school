using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class Users
    {
        [Required]
        public Student[] users {get; set;}
    }
}
