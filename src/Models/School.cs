using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace School
{
    public class School
    {
        [Required]
        public List<Student> users {get; set;}
    }
}
