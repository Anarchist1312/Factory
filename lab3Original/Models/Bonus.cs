namespace lab3Original.Models
{
    public class Bonus : CSVParser <Bonus>
    {
        public int Id { get; set; }
        
        public int Amount { get; set; }

        public static Bonus Parse(string s)
        {
            var words = s.Split(@"; ");
            if (words.Length != 2 || !int.TryParse(words[0], out int id) || !int.TryParse(words[1], out int amount))
            {
                throw new FormatException($"Error in the delivery parsing from the line {s}");
            }
            return new Bonus { Id = id, Amount = amount };
        }
    }
}
