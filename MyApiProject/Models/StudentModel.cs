using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.Models
{
    public record StudentModel
    {
        
        public int StudentID { get; set; }

       
        public string FirstName { get; set; }

        
        public string LastName { get; set;}

        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [EmailAddress]
        public string Email {get; set;}

        public string PhoneNumber {get; set;}

    }
}