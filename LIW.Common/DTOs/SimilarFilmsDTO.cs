using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIW.Common.DTOs
{
	public class SimilarFilmsDTO
	{
        //public int ParentFilmId { get; set; }

        //public int SimilarFilmId { get; set; }

        //public FilmDTO Film { get; set; }
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }

        public FilmDTO Film { get; set; }
        public FilmDTO Similar { get; set; }
    }
}
