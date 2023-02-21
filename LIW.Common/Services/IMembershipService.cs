namespace LIW.Common.Services
{
	public interface IMembershipService
	{
		Task<FilmDTO> GetCourseAsync(int? id);
		Task<List<FilmDTO>> GetFilmsAsync();
	}
}