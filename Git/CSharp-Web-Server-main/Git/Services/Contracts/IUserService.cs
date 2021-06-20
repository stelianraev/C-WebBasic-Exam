namespace Git.Services.Contracts
{
    using Git.ViewModels.UserViewModels;
    public interface IUserService
    {
        void Create(RegisterInputModel model);
    }
}
