using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.ComponentModel.DataAnnotations;


namespace lab3Original.Models
{
    public class UserProvider
    {
        private static Dictionary<string, User> _users = new();
        private static string _fullPathName = Path.Combine(".//App_Data", "users.txt");

        static UserProvider()
        {
            ReadUsers();
        }

        public string Name { get; set; }

        public static bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }

        public static bool isLoggedIn(User user)
        {
            return _users.ContainsKey((string)user.Name) && _users[user.Name].Password == user.Password;
        }

        public static bool TryAddUser(User user)
        {
            var result = false;
            if (!_users.ContainsKey(user.Name))
            {
                try
                {
                    using var writer = new StreamWriter(_fullPathName, append: true);
                    _users.Add(user.Name, user);
                    writer.Write($"\n{user}");
                    result = true;
                    Trace.WriteLine($"{DateTime.Now:HH:mm:ss}: {user.Name} is saved in {_fullPathName}");
                }
                catch (IOException e)
                {
                    Trace.WriteLine(
                        $"{DateTime.Now.TimeOfDay}: {user.Name} saving in {_fullPathName} failed with exception: {e.Message}");
                }
            }

            return result;
        }

        public static void ReadUsers()
        {
            var userList = DataProvider.ReadData<User>("users.txt", ".//App_Data");
            foreach (var user in userList)
            {
                _users.TryAdd(user.Name, user);
            }
        }
    }
}
