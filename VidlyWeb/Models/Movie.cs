using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyWeb.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required]
        [Range(0, 2500, ErrorMessage = "Out of range.")]
        public int NumberInStock { get; set; }

        [Required]
        [Range(1, 4)]
        public virtual int GenreId
        {
            get => (int)GenreName;
            set => GenreName = (Genres)value;
        }

        [EnumDataType(typeof(Genres))]
        [NotMapped]
        public Genres GenreName { get; set; }
        public enum Genres
        {
            Comedy = 1,
            Action,
            Horror,
            Thriller
        }
    }
}
