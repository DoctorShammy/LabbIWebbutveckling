

using System.ComponentModel.DataAnnotations.Schema;

namespace LIW.Membership.Database.Enteties
{
	public class SimilarFilmscs : IReferenceEntity
    {
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }

        public virtual Film Film { get; set; } = null!;
        [ForeignKey("SimilarFilmId")]
        public virtual Film Similar { get; set; } = null!;


    }
}
