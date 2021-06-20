using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Data
{
    public class Constants
    {
        public const int UserUsernameMaxLength = 20;
        public const int UserUsernameMinLength = 5;

        public const int UserPasswordMaxLenght = 20;
        public const int UserPasswordMinLenght = 6;

        public const int RepositoryNameMaxLenght = 10;
        public const int RepositoryNameMinLenght = 3;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

    }
}
