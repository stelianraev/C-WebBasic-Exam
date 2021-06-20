namespace Git.Services
{
    using Git.Data;
    using Git.Services.Contracts;
    using Git.ViewModels.UserViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.Constants;

    public class ValidationService : IValidationService
    {
        private readonly GitDbContext db;
        private readonly PasswordHashing passwordHashing;

        public ValidationService(GitDbContext db, PasswordHashing passwordHashing)
        {
            this.db = db;
            this.passwordHashing = passwordHashing;
        }
        public ICollection<string> ValidateRegisterInput(RegisterInputModel model)
        {
            List<string> errors = new();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add("Username should be between 5 and 20 characters.");
            }

            if (string.IsNullOrEmpty(model.Email) || !Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add("Invalid Email address.");
            }

            if(model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add("Password should be between 6 and 20 characters");
            }

            if (this.db.Users.Any(x => x.Username == model.Username))
            {
                errors.Add("Username already exist.");
            }

            if (this.db.Users.Any(x => x.Email == model.Email))
            {
                errors.Add("Email already exist.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Passwords does not match");
            }

            return errors;
        }
        public string ValidateLoginInput(LoginInputModel model)
        {           
            var hashedPassword = this.passwordHashing.ComputeHash(model.Password);

            var user = this.db.Users.Where(x => x.Username == model.Username && x.Password == hashedPassword).FirstOrDefault();

            if(user == null)
            {
                return "Incorrect username or password";
            }

            return user.Id;
        }
    }
}
