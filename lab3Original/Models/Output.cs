using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3Original.Models
{
	public class Output
	{
		public int task1res { get; set; }
		public Dictionary<int,int> task2res { get; set; }
		public List<Bonus> outputBonuses { get; set; }
		public List<Factory> outputFactories{ get; set; }
    }
}
