using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace School
{
    public class PrivateSchool

    {
        [Required]
        public List<PrivateStudent> users {get; set;}
        public List<string> errorData { get; set; }
        public void ValidateCsvContent(IFormFile uploadFile)
        {
            errorData = new List<string>();
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream()))
            {
                users = new List<PrivateStudent>();
                string[] rowData = streamReader.ReadToEnd().Split(Environment.NewLine);
                for (int i = 1; i < rowData.Length; i++)
                {
                    if (rowData[i] != "")
                    {
                        PrivateStudent student = new PrivateStudent();
                        student.setData(rowData[0], rowData[i]);
                        foreach (var item in student.parent)
                        {
                            if (item.invalidFields.Count > 0)
                            {
                                string errors = string.Join(",", item.invalidFields.ToArray());
                                student.invalidFields.Add(errors);
                            }
                        }
                        if (student.invalidFields.Count > 0)
                        {
                            string errors = string.Join(",", student.invalidFields.ToArray());
                            errorData.Add("Row csv data File[" + (i + 1).ToString() + "]: Missing data for: " + errors);
                        }
                        users.Add(student);
                    }
                }
            }
        }
    }
}
