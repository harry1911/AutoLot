using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoLot.Dal.Models.Entities.Owned
{   [Owned]
    public class Person
    {
        [StringLength(50)]
        public string  FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
