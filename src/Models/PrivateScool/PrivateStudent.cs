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
            
            this.userId = findItemByHeader(header, "test 1" , rowData);
            this.firstname = findItemByHeader(header, "test 2", rowData);
            this.middlename = findItemByHeader(header, "test 3", rowData);  
            this.lastname = findItemByHeader(header, "test 4", rowData);
            this.address = findItemByHeader(header, "test 5", rowData);
            this.studentId = findItemByHeader(header, "test 6", rowData);
            this.phone = findItemByHeader(header, "test 7", rowData);

            List<Person> listOfParents = new List<Person>();

            Person mother = new Person();
            mother.firstname = findItemByHeader(header, "test 8", rowData);
            mother.lastname = findItemByHeader(header, "test 9", rowData);
            mother.phone = findItemByHeader(header, "test 10", rowData);
            listOfParents.Add(mother);

            Person father = new Person();
            father.firstname = findItemByHeader(header, "test 11", rowData);
            father.lastname = findItemByHeader(header, "test 12", rowData);
            father.phone = findItemByHeader(header, "test 13", rowData);
            listOfParents.Add(father);

            this.parent = listOfParents;  

            this.note = findItemByHeader(header, "test 14", rowData);  
        }
    }
}
