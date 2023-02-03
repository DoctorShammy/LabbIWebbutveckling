﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIW.Common.DTOs
{
	public class FilmGenreDTO
	{
		public int FilmId { get; set; }

		public int GenreId { get; set; }

		public FilmDTO Film { get; set; }

		public GenreDTO Genre { get; set; }
	}
}
