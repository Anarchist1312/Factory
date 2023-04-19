using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace lab3Original.Models
{
    public class User : CSVParser<User>
    {
        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public static User Parse(string s)
        {
            var words = s.Split("; ");
            if (words.Length != 2)
            {
                throw new FormatException($"Error in the user parsing from the line {s}");
            }
            return new User { Name = words[0], Password = words[1] };
        }
        public override string ToString() => $"{Name}; {Password}";
    }
}
