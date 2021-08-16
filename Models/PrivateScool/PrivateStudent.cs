using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class PrivateStudent: Student
    {
        [Required]
        new public Person[] parent {get; set;}
    }
}
