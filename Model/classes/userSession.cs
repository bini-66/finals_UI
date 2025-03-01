using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace finals_UI.Model.classes
{
    public static class userSession
    {
        public static int userId { get; private set; }
        public static string userName { get; private set; }
        public static string role { get; private set; }
        public static bool IsLoggedIn { get; private set; } = false;

        public static void Login(int userId, string username, string role)
        {
            userSession.userId = userId;  
            userSession.userName = username;
            userSession.role = role;
            IsLoggedIn = true;
        }

        public static void Logout()
        {
            userId = 0;
            userName = string.Empty;
            role = string.Empty;
            IsLoggedIn = false;
        }
    }
}