using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace School
{
    public class PrivateStudent: Student
    {
        [Required]
        [MinLength(1, ErrorMessage = "You must enter at least one parent.")]
        new public List<Person> parent {get; set;}

        new public void setData(string header, string rowData)
        {
            int ind = findHeaderIndex(header, "test");
            // Console.Write();
            string[] data = rowData.Split(",");

            if (!dataValid(data, 14)) return;
            this.userId = data[0];
            this.firstname = data[1];
            this.middlename = data[2];  
            this.lastname = data[3];
            this.address = data[4];
            this.studentId = data[5];
            this.phone = data[6];

            List<Person> listOfParents = new List<Person>();

            Person mother = new Person();
            mother.firstname = data[7];
            mother.lastname = data[8];
            mother.phone = data[9];
            listOfParents.Add(mother);

            Person father = new Person();
            father.firstname = data[10];
            father.lastname = data[11];
            father.phone = data[12];
            listOfParents.Add(father);

            this.parent = listOfParents;  

            this.note = data[13];  
        }
    }
}
