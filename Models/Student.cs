using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class Student: Person
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string studentId { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public Person parent {get; set;}
    }
}
