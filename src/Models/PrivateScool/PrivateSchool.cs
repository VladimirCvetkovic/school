using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class PrivateSchool

    {
        [Required]
        public PrivateStudent[] users {get; set;}
    }
}
