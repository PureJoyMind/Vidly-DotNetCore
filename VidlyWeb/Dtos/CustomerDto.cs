using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using VidlyWeb.Models;

namespace VidlyWeb.Dtos
{
    [AutoMap(typeof(Customer))]
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name value is required!")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDateTime { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }

        // Sometimes we only need the foreign key of another type 
        public byte MembershipTypeId { get; set; }
    }
}
