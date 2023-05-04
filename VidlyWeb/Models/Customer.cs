using System.ComponentModel.DataAnnotations;

namespace VidlyWeb.Models
{
    
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name value is required!")]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime? BirthDateTime { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        
        // Sometimes we only need the foreign key of another type 
        public byte MembershipTypeId { get; set; }
    }
}
