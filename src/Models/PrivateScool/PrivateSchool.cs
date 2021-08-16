using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace School
{
    public class PrivateSchool

    {
        [Required]
        public List<PrivateStudent> users {get; set;}
    }
}
