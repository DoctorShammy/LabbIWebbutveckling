using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIW.Common.DTOs
{
	public class FilmDTO
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public string Title { get; set; }

		public DateTime Released { get; set; }

		public int DirectorId { get; set; }

		public bool Free { get; set; }

		public string Description { get; set; }

		public string FilmUrl { get; set; }

		public List<SimilarFilmsDTO> SimilarFilmscss { get; set; }
		public List<FilmGenreDTO> FilmGenres { get; set; } = new();
	}
    public class FilmCreateDTO
    {
        public string Title { get; set; }

        public DateTime Released { get; set; } 
        public int DirectorId { get; set; }

        public bool Free { get; set; }

        public string Description { get; set; }

        public string FilmUrl { get; set; }
    }
    public class FilmEditDTO : FilmCreateDTO
    {
        public int Id { get; set; }
    }
}
