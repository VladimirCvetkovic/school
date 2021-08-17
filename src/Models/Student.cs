using System;
using System.ComponentModel.DataAnnotations;

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

        public void setData(string rowData)
        {
            string[] data = rowData.Split(",");
            if(!dataValid(data)) return;

            this.userId = data[0];
            this.firstname = data[1];
            this.middlename = data[2];
            this.lastname = data[3];
            this.address = data[4];
            this.studentId = data[5];
            this.phone = data[6];
            this.note = data[10];

            Person studentParent = new Person();
            studentParent.firstname = data[7];
            studentParent.lastname = data[8];
            studentParent.phone = data[9];
            this.parent = studentParent;
        }

        public bool dataValid(string[] data)
        {
            if (data.Length < 11) return false;
            return true;
        }
    }
}
