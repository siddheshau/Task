using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInformationSystem
{
    /// <summary>
    /// This class will contain only user credentials
    /// </summary>
    public class UserCredentials
    {
        public static Dictionary<string, string> userCredentials = new Dictionary<string, string>();
        public UserCredentials()
        {
            userCredentials.Add("siddhesh", "siddhesh");
            userCredentials.Add("vimal", "vimal");
            userCredentials.Add("bipin", "bipin");
        }
    }
}
