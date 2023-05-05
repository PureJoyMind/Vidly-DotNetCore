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
        public DateTime? BirthDateTime { get; set; }

        [DisplayName("Is Subscribed To Newsletter?")]
        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [DisplayName("Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Range(1, 4, ErrorMessage = "Wrong Type")]
        // Sometimes we only need the foreign key of another type 
        public byte MembershipTypeId { get; set; }
    }
}
