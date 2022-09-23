using ASPWeb.API.Data;
using ASPWeb.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPWeb.API.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly CaseDBContext caseBDContext;

        public CaseRepository(CaseDBContext caseBDContext)
        {
            this.caseBDContext = caseBDContext;
        }

        public async Task<Case> AddAsync(Case caseadd)
        {
            caseadd.GlobalID= Guid.NewGuid();
            await caseBDContext.AddAsync(caseadd);
            await caseBDContext.SaveChangesAsync();
            return caseadd;
        }

        public async Task<Case> DeleteAsync(Guid GlobalID)
        {
            var caseid= await caseBDContext.Cases.FirstOrDefaultAsync(c=>c.GlobalID==GlobalID);
            if (caseid==null)
            {
                return null;
            }

            // Delete the case
            caseBDContext.Cases.Remove(caseid);
            await caseBDContext.SaveChangesAsync();
            return caseid;

        }

        public async Task< IEnumerable<Case>> GetAllAsync()
        {
            return await caseBDContext.Cases.ToListAsync();
        }

        public async Task<Case> GetAsync(Guid GlobalID)
        {
           return  await caseBDContext.Cases.FirstOrDefaultAsync(x => x.GlobalID == GlobalID);

        }
    }
}
