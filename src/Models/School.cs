using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class School
    {
        [Required]
        public Student[] users {get; set;}
    }
}
