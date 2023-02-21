
namespace LIW.Common.Services
{
	public class MembershipService : IMembershipService
	{
		protected readonly MembershipHttpClient _http;
		//private readonly IStorageService _storage;
		//protected readonly ILocalStorageService _localStorage;

		public MembershipService(MembershipHttpClient httpClient)//, IStorageService storage, ILocalStorageService localStorage)
		{
			_http = httpClient;
			//_storage = storage;
			//_localStorage = localStorage;
		}
		public async Task<List<FilmDTO>> GetFilmsAsync()
		{
			try
			{
				//var token = await _storage.GetAsync(AuthConstants.TokenName);

				bool freeOnly = false;//JwtParser.ParseIsNotInRoleFromPayload(token, UserRole.Customer);

				//_http.AddBearerToken(token);

				using HttpResponseMessage response = await _http.Client.GetAsync($"courses?freeOnly={freeOnly}");
				response.EnsureSuccessStatusCode();

				var result = JsonSerializer.Deserialize<List<FilmDTO>>(await response.Content.ReadAsStreamAsync(),
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

				return result ?? new List<FilmDTO>();
			}
			catch
			{
				return new List<FilmDTO>();
			}
		}

		public async Task<FilmDTO> GetCourseAsync(int? id)
		{
			try
			{
				if (id is null) return new FilmDTO();
				using HttpResponseMessage response = await _http.Client.GetAsync($"films/{id}");
				response.EnsureSuccessStatusCode();

				var result = JsonSerializer.Deserialize<FilmDTO>(await response.Content.ReadAsStreamAsync(),
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

				return result ?? new FilmDTO();
			}
			catch
			{
				return new FilmDTO();
			}
		}

		//Behöver man en till getasync? 

	}
}
