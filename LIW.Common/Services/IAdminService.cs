namespace LIW.Common.Services
{
    public interface IAdminService
    {
        Task<List<TDto>> GetAsync<TDto>(string uri);
    }
}