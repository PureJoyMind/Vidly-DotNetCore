
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyWeb.Models
{

    public class MembershipType
    {
        // Key should either be Id or name of the type + id
        [Key]
        public byte Id { get; set; }

        [Range(1, 4)]
        [DisplayName("Membership Type")]
        public virtual int NameId
        {
            get => (int)this.Name;
            set => Name = (MemberShipNames)value;
        }

        [EnumDataType(typeof(MemberShipNames))]
        [NotMapped]
        public MemberShipNames Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationMonth { get; set; }

        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public byte DiscountRate { get; set; }


        public enum MemberShipNames
        {
            PayAsYouGo = 1,
            Monthly,
            Quarterly,
            Annual
        }
    }
}
