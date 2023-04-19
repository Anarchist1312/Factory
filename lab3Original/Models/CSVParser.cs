namespace lab3Original.Models
{
    public interface CSVParser <out T>
    {
        public static abstract T Parse(string s);
    }
}
