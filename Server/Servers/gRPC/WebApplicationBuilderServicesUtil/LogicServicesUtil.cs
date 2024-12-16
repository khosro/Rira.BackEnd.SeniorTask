using Microsoft.EntityFrameworkCore;
using Rira.BackEnd.SeniorTask.Logic;
using Rira.BackEnd.SeniorTask.Repository;
using Rira.BackEnd.SeniorTask.RepositoryEFImpl;

namespace Rira.BackEnd.SeniorTask.gRPC.WebApplicationBuilderServices
{
    public static class LogicServicesUtil
    {
        public static void LogicServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<PersonLogic>();
        }
    }
}
