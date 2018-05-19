using System;
using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class Note
    {
        // Id of the note
        public int? Id { get; set; }

        // FirstName of the note, length between 2-15
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Invalid name length")]
        public string FirstName { get; set; }

        // LastName of the note, length between 2-15
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Invalid lastname length")]
        public string LastName { get; set; }

        // YearOfBirth of the note, min = 1900
        [Required]
        [RangeUntilCurrentYear(1900, ErrorMessage = "Invalid year: min = 1900")]
        public int YearOfBirth { get; set; }

        // Telephone number of the note, Number Format +xxxxxxxxxxx
        [Required]
        [RegularExpression(@"^\+[2-9]\d{3}\d{3}\d{4}$", ErrorMessage = "Number Format +xxxxxxxxxxx")]
        public String PhoneNumber { get; set; }


        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {YearOfBirth} {PhoneNumber}";
        }
    }

    // Constructor for YearofBirth with min value
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        public RangeUntilCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }
}
