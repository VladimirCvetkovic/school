using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace School
{
    public class Person
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string phone { get; set; }
        [JsonIgnore]
        public List<string> invalidFields { get; set; }

        public void setInvalidFieldsList(string header, string data, string[] requieredFilds)
        {
            string[] headers = header.ToUpper().Split(",");
            for (int i = 0; i < requieredFilds.Length; i++)
            {
                string cellData = findItemByHeader(header, requieredFilds[i], data);
                if (cellData == "") invalidFields.Add(requieredFilds[i]);
            }
        }

        public string findItemByHeader(string headerNames, string header, string rowData)
        {
            string[] headers = headerNames.ToUpper().Split(",");
            string[] data = rowData.Split(",");
            int headerIndex = Array.IndexOf(headers, header);
            if (headerIndex < 0) return "";
            else return data[headerIndex];
        }
    }
}
