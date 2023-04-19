using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab3Original.Models
{
	public class DataProvider
	{
		private const string _DefaultDataDir = ".//App_Data";
		public static Dictionary<int, Factory> Workers = new();
		public static List<Bonus> bonus = ReadData<Bonus>("Bonuses.csv");
		public static List<Factory> workers = ReadData<Factory>("Workers.csv");
		private static Dictionary<int, int> _HasBonus = CheckBonus();
		private static List<int> _WorkersInRange = CheckWorkersInRange();
		public static Dictionary<int, int> CheckBonus()
		{
			Dictionary<int, int> Checks = new();
			foreach(var i in bonus)
			{
				if (Checks.ContainsKey(i.Id))
				{
					Checks[i.Id] += i.Amount;
				}
				else
				{
					Checks.Add(i.Id, i.Amount);
				}
			}
			return Checks;

		}
		public static List<int> CheckWorkersInRange()
		{
			List<int> ans = new();
			foreach(var i in workers)
			{
				Workers.Add(i.Id, i);
				if (i.Experience == Math.Clamp(i.Experience, 10, 20))
					ans.Add(i.Id);
			}
			return ans;
		}
		public static Dictionary<int, int> Task2()
		{
			Dictionary<int, int> ans = new();
			foreach(var i in _WorkersInRange)
			{
				if (ans.ContainsKey(Workers[i].DepartmentNumber))
				{
					ans[Workers[i].DepartmentNumber] = Math.Max(ans[Workers[i].DepartmentNumber], Workers[i].Salary + _HasBonus[i]);
				}
				else ans.Add(Workers[i].DepartmentNumber, Workers[i].Salary + _HasBonus[i]);
			}
			return ans;
		}
		public static int Task1()
		{
			Dictionary<string, bool> posts = new();
			foreach (Factory factory in workers)
			{
				if (!factory.IsMale && _HasBonus.ContainsKey(factory.Id))
				{
					if(!posts.ContainsKey(factory.Post))
					{
						posts.Add(factory.Post, true);
					}
				}
			}
			return posts.Count;
		}

		public static List<T> ReadData<T>(string fileName, string? dataDir = null)
		where T : CSVParser<T>
		{
			var items = new List<T>();
			dataDir ??= _DefaultDataDir;
			int lineNumber = 0;
			var fullName = Path.Combine(dataDir, fileName);

			try
			{
				foreach (var line in File.ReadAllLines(fullName))
				{
					lineNumber++;
					try
					{
						var item = T.Parse(line);
						items.Add(item);
					}
					catch (Exception)
					{
						Trace.WriteLine($"{fullName}: inconsistent data in line #{lineNumber}");
					}
				}
			}
			catch (Exception e)
			{
				Trace.WriteLine($"{fullName}: exception {e.Message}");
			}

			return items;
		}

	}
}
