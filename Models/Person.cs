using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class Person
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Middlename { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
