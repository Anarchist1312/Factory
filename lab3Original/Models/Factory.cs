using Microsoft.Build.Framework;
using System.Diagnostics;

namespace lab3Original.Models
{
	public class Factory : CSVParser<Factory>
	{
		private static Dictionary<int, bool> usedIds = new();
		[Required]
		public int Id { get; set; }
		[Required]
		public string Surname { get; set; }
		[Required]
		public bool IsMale { get; set; }
        [Required]
        public int DepartmentNumber { get; set; }
        [Required] 
		public string Post { get; set; }
        [Required] 
		public double Experience { get; set; }
		[Required]
        public int Salary { get; set; }


		public static Factory Parse(string s)
		{
			var words = s.Split(@"; ");
			if (words.Length != 7 || !int.TryParse(words[0], out int id) || !bool.TryParse(words[2], out bool ismale) || !int.TryParse(words[3], out int departmentnumber) || !double.TryParse(words[5], out double experience) || !int.TryParse(words[6], out int salary) || experience < 0 || salary < 0 || usedIds.ContainsKey(id))
			{
				throw new FormatException($"Error in the worker parsing from the line {s}");
			}
            usedIds.Add(id, true);
            return new Factory { Id = id, Surname = words[1], IsMale = ismale, DepartmentNumber = departmentnumber, Post = words[4], Experience = experience, Salary = salary };
		}

	//	public override string ToString() => $"{Id}	{Surname}	{IsMale}	{DepartmentNumber}	{Post}	{Experience}	{Salary}";
	}

}

