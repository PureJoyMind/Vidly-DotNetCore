using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyWeb.Models
{
    
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name value is required!")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Birth Date")]
        [Min18YearsIfMember]
        public DateTime? BirthDateTime { get; set; }

        [DisplayName("Is Subscribed To Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }

        [DisplayName("Membership Type")]
        // Sometimes we only need the foreign key of another type 
        public byte MembershipTypeId { get; set; }
    }
}
