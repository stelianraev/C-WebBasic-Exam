namespace Git
{
    using Git.Data;
    using Git.Services;
    using Git.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
               => await HttpServer
                    .WithRoutes(routes => routes
                        .MapStaticFiles()
                        .MapControllers())
                    .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUserService, UserService>()
                    .Add<IPasswordHashing, PasswordHashing>()
                    .Add<IValidationService, ValidationService>()
                    .Add<GitDbContext>())
                    .WithConfiguration<GitDbContext>(c => c.Database.Migrate())
                    .Start();
        }
}
