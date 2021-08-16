using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class Person
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
