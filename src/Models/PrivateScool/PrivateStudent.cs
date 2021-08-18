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
            this.invalidFields = new List<string>();
            this.userId = findItemByHeader(header, "USERID" , rowData);
            this.firstname = findItemByHeader(header, "STUDENTFIRSTNAME", rowData);
            this.middlename = findItemByHeader(header, "STUDENTMIDDLENAME", rowData);  
            this.lastname = findItemByHeader(header, "STUDENTLASTNAME", rowData);
            this.address = findItemByHeader(header, "STUDENTADDRESS", rowData);
            this.studentId = findItemByHeader(header, "STUDENTID", rowData);
            this.phone = findItemByHeader(header, "STUDENTPHONE", rowData);
            this.note = findItemByHeader(header, "NOTE", rowData); 
            this.parent = createParensData(header, rowData); 
            if (this.parent.Count == 0) invalidFields.Add("PARENTS");

            setInvalidFieldsList(header, rowData, requieredFilds);
        }

        public List<Person> createParensData(string header, string rowData){

            List<string[]> parents = new List<string[]>();
            List<Person> listOfParents = new List<Person>();

            parents.Add(requieredMotherFilds);
            parents.Add(requieredFatherFilds);

            for (int i = 0; i < parents.Count; i++)
            {
                Person parent = new Person();
                parent.invalidFields = new List<string>();
                parent.firstname = findItemByHeader(header, parents[i].GetValue(0).ToString() , rowData);
                parent.lastname = findItemByHeader(header, parents[i].GetValue(1).ToString(), rowData);
                parent.phone = findItemByHeader(header, parents[i].GetValue(2).ToString() , rowData);
                parent.setInvalidFieldsList(header, rowData, parents[i]);
                if(parent.invalidFields.Count != 3)listOfParents.Add(parent);
            }

            return listOfParents;
        }
    }
}
