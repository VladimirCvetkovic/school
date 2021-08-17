using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace School
{
    public class Student : Person
    {
        [Required]
        public string middlename { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public string studentId { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public Person parent { get; set; }
        public string note { get; set; }

        private string[] requieredFilds = {"USERID", "FIRSTNAME", "MIDDLENAME", "LASTNAME", "ADDRESS", "STUDENTID", "PHONE"};
        private string[] requieredParentFilds = {"PARENTFIRSTNAME", "PARENTLASTNAME", "PARENTPHONE"};

        public void setData(string header, string rowData)
        {
            this.invalidFields = new List<string>();

            this.userId = findItemByHeader(header, "USERID" , rowData);
            this.firstname = findItemByHeader(header, "FIRSTNAME", rowData);
            this.middlename = findItemByHeader(header, "MIDDLENAME", rowData);  
            this.lastname = findItemByHeader(header, "LASTNAME", rowData);
            this.address = findItemByHeader(header, "ADDRESS", rowData);
            this.studentId = findItemByHeader(header, "STUDENTID", rowData);
            this.phone = findItemByHeader(header, "PHONE", rowData);
            this.note = findItemByHeader(header, "NOTE", rowData);

            Person studentParent = new Person();
            studentParent.invalidFields = new List<string>();
            studentParent.firstname = findItemByHeader(header, "PARENTFIRSTNAME", rowData);
            studentParent.lastname = findItemByHeader(header, "PARENTLASTNAME", rowData);
            studentParent.phone = findItemByHeader(header, "PARENTPHONE", rowData);
            studentParent.setStudentErrorReasonsList(header, rowData, requieredParentFilds);

            this.parent = studentParent;

            setStudentErrorReasonsList(header, rowData, requieredFilds);
        }

        
    }
}
