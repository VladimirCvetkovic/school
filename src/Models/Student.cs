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

        public void setData(string header, string rowData)
        {
            string[] data = rowData.Split(",");
            if(!dataValid(data, 11)) return;

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

        public bool dataValid(string[] data, int maxLength)
        {
            if (data.Length < maxLength) return false;
            return true;
        }

        public string findItemByHeader(string headerNames, string header, string rowData){
            string[] headers = headerNames.ToLower().Split(",");
            string[] data = rowData.Split(",");
            int headerIndex = Array.IndexOf(headers, header);
            if (headerIndex<0) return null;
            else return data[headerIndex];
        }
    }
}
