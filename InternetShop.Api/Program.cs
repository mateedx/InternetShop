
namespace InternetShop.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            
            .Build(); 

        CreateHostBuilder(config).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(IConfiguration configuration)
        => Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                    
                .UseStartup<Startup>()
                .UseConfiguration(configuration));
    
}

