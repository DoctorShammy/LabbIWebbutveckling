

namespace LIW.Membership.Database.Enteties
{
	public class SimilarFilmscs
	{
		public int ParentFilmId { get; set; }

		public int SimilarFilmId { get; set; }

		public virtual Film Film { get; set; }


	}
}
