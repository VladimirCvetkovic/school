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

        private string[] requieredFilds = {"USERID","STUDENTFIRSTNAME","STUDENTMIDDLENAME","STUDENTLASTNAME","STUDENTADDRESS","STUDENTID","STUDENTPHONE"};
        private string[] requieredMotherFilds = {"MOTHERFIRSTNAME","MOTHERLASTNAME","MOTHERPHONE"};
        private string[] requieredFatherFilds = {"FATHERFIRSTNAME","FATHERLASTNAME","FATHERPHONE"};
        new public void setData(string header, string rowData)
        {
            this.userId = findItemByHeader(header, "USERID" , rowData);
            this.firstname = findItemByHeader(header, "STUDENTFIRSTNAME", rowData);
            this.middlename = findItemByHeader(header, "STUDENTMIDDLENAME", rowData);  
            this.lastname = findItemByHeader(header, "STUDENTLASTNAME", rowData);
            this.address = findItemByHeader(header, "STUDENTADDRESS", rowData);
            this.studentId = findItemByHeader(header, "STUDENTID", rowData);
            this.phone = findItemByHeader(header, "STUDENTPHONE", rowData);
            this.note = findItemByHeader(header, "NOTE", rowData); 

            List<Person> listOfParents = new List<Person>();

            Person mother = new Person();
            mother.firstname = findItemByHeader(header, "MOTHERFIRSTNAME", rowData);
            mother.lastname = findItemByHeader(header, "MOTHERLASTNAME", rowData);
            mother.phone = findItemByHeader(header, "MOTHERPHONE", rowData);
            mother.setStudentErrorReasonsList(header, rowData, requieredMotherFilds);
            listOfParents.Add(mother);

            Person father = new Person();
            father.firstname = findItemByHeader(header, "FATHERFIRSTNAME", rowData);
            father.lastname = findItemByHeader(header, "FATHERLASTNAME", rowData);
            father.phone = findItemByHeader(header, "FATHERPHONE", rowData);
            father.setStudentErrorReasonsList(header, rowData, requieredFatherFilds);
            listOfParents.Add(father);

            this.parent = listOfParents;  

            setStudentErrorReasonsList(header, rowData, requieredFilds);
             
        }
    }
}
