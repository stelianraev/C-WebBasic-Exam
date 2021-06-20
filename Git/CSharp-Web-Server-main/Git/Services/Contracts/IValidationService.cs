namespace Git.Services.Contracts
{
    using Git.ViewModels.UserViewModels;
    using System.Collections.Generic;

    public interface IValidationService
    {
        ICollection<string> ValidateRegisterInput(RegisterInputModel model);
    }
}
