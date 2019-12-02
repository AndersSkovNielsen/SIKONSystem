using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class UserSingleton
    {
        private static UserSingleton _instance;

        public static UserSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new UserSingleton();
            }

            return _instance;
        }

        private UserSingleton()
        {

        }

        public bool Create(User U)
        {
            return false;
        }
    }
}
