using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PARSAcc.ViewComponents;
using System.Data;

namespace PARSAcc
{
    public class ConfigurationServices
    {
        public static void ConfigureService(IServiceCollection services)
        {
            //services.AddScoped<IDbConnection>((sp) =>
            //{
            //    var config = sp.GetRequiredService<IConfiguration>();
            //    var connectionString = config.GetConnectionString("DefaultConnection");
            //    return new SqlConnection(connectionString);
            //});
           //services.AddSingleton<SidebarViewCompent>();
        }
    }
}
