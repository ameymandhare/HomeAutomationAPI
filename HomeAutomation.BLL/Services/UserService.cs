using HomeAutomation.Common.Entity;
using HomeAutomation.DAL;
using System.Collections.Generic;

namespace HomeAutomation.BLL.Services
{
    public class UserService
    {
        public bool RegisterUser(Consumer consumer)
        {
            var userRepository = new UserRepository();
            return userRepository.RegisterUser(consumer);
        }

        public List<Device> Authenticate(Authentication authInfo)
        {
            var userRepository = new UserRepository();
            return userRepository.Authenticate(authInfo);
        }
    }
}
