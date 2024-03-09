using System.ComponentModel.DataAnnotations.Schema;

namespace TunaPiano.Models
{
    public class SongGenre
    {
        public int Id { get; set; }

        [ForeignKey("Song")]
        public int SongId { get; set; }
        public Song Song { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

