using Microsoft.EntityFrameworkCore;
using Rira.BackEnd.SeniorTask.Repository;
using Rira.BackEnd.SeniorTask.RepositoryEFImpl;

namespace Rira.BackEnd.SeniorTask.gRPC.WebApplicationBuilderServices
{
    public static class RepositoryServicesUtil
    {
        public static void RepositoryServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPersonRepository, PersonEFRepository>();

        }
    }
}
