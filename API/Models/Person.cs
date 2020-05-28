using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "LastName can not be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "FirstName can not be empty")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

    }
}