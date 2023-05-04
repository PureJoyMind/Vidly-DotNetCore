
using System.ComponentModel.DataAnnotations;

namespace VidlyWeb.Models
{
    public enum MemberShipNames
    {
        PayAsYouGo = 1,
        Monthly,
        Quarterly,
        Annual
    }

    public class MembershipType
    {
        // Key should either be Id or name of the type + id
        [Key]
        public byte Id { get; set; }

        public MemberShipNames Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationMonth { get; set; }

        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public byte DiscountRate { get; set; }

    }
}
