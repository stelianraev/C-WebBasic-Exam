namespace Git.Controllers
{
    using Git.Data;
    using Git.Services;
    using Git.ViewModels.UserViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly GitDbContext db;
        private readonly ValidationService validationService;
        private readonly UserService userService;

        public UsersController(GitDbContext db, ValidationService validationService, UserService userService)
        {
            this.db = db;
            this.validationService = validationService;
            this.userService = userService;
        }
        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            var modelErrors =  this.validationService.ValidateRegisterInput(model);

            if (modelErrors.Any())
            {
                return this.Error(modelErrors);
            }

            this.userService.Create(model);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login() => this.View();

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            var modelErrors = this.validationService.ValidateLoginInput(model);

            if (modelErrors.Any())
            {
                return this.Error(modelErrors);
            }
            
            SignIn()
            return this.Redirect("Repositories/All ");
        }
    }
}
