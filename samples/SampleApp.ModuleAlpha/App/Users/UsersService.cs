using SampleApp.ModuleAlpha.App.Users.Input;
using SampleApp.ModuleAlpha.App.Users.Output;

namespace SampleApp.ModuleAlpha.App.Users
{
    internal sealed class UsersService
    {

        public async Task<long> CreateUser(CreateUser createUser)
        {
            return 69;
        }


        public async Task<IList<UserDTO>> GetUsers(ReadUsers readUsers)
        {
            var result = new List<UserDTO>();
            return result;
        }
    }
}
