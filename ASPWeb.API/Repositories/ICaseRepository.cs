using ASPWeb.API.Models.Domain;

namespace ASPWeb.API.Repositories
{
    public interface ICaseRepository
    {

        Task<IEnumerable<Case>> GetAllAsync();

        Task<Case> GetAsync(Guid GlobalID);

        Task<Case> AddAsync(Case caseadd);

        Task<Case>DeleteAsync(Guid GlobalID);

    }
}