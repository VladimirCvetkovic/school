using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    public class PrivateStudent: Student
    {
        [Required]
        [MinLength(1, ErrorMessage = "You must enter at least one parent.")]
        new public Person[] parent {get; set;}

        new public void setData(string rowData)
        {
            string[] data = rowData.Split(",");
            this.userId = data[0];
            this.firstname = data[1];
            this.middlename = data[2];  
            this.lastname = data[3];
            this.address = data[4];
            this.studentId = data[5];
            this.phone = data[6];  
            this.parent[0].firstname = data[7];  
            this.parent[0].lastname = data[8];  
            this.parent[0].phone = data[9];
            this.parent[1].firstname = data[7];  
            this.parent[1].lastname = data[8];  
            this.parent[1].phone = data[9];
            this.note = data[10];  
        }
    }
}
