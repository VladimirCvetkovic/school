using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class Student: Person
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Parent[] Parents {get; set;}
    }
}
