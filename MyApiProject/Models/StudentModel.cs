using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.Models
{
    public record StudentModel
    {

        public int StudentID { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }



        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Gender { get; set; }

        public string Ethnicity { get; set; }

        public string Department { get; set; }

    }
}