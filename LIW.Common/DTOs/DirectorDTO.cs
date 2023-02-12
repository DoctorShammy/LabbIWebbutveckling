using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIW.Common.DTOs
{
	public class DirectorDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		//public List<FilmDTO> Films { get; set; } = new();
	}

    public class DirectorCreateDTO
    {
        public string Name { get; set; }
    }
}
