namespace Git.Services
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services.Contracts;
    using Git.ViewModels.UserViewModels;
    public class UserService : IUserService
    {
        private readonly GitDbContext db;
        private readonly PasswordHashing passwordHashing;

        public UserService(GitDbContext db, PasswordHashing passwordHashing)
        {
            this.db = db;
            this.passwordHashing = passwordHashing;
        }
        public void Create(RegisterInputModel model)
        {
            User user = new()
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHashing.ComputeHash(model.Password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }
    }
}
