namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.UserViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {         
       
        public HttpResponse Index()
        {           
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
