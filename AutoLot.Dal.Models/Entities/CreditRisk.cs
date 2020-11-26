using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Dal.Models.Entities.Base;
using AutoLot.Dal.Models.Entities.Owned;

namespace AutoLot.Dal.Models.Entities
{
    public partial class CreditRisk : BaseEntity
    {
        public int CustomerId { get; set; }
        public Person PersonalInformation { get; set; } = new Person();

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.CreditRisks))]
        public virtual Customer? CustomerNavigation { get; set; }
    }
}
