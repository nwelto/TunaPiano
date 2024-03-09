﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<SongGenre> SongGenres { get; set; }
    }
}


