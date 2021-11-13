using System.Collections.Generic;

namespace _Source.Scripts
{
	public class Request
	{
		public Request(RequestBlueprint blueprint, bool completed)
		{
			Blueprint = blueprint;
			Completed = completed;
		}

		public List<TaskChecker> OwnTaskCheckers { get; set; } = new List<TaskChecker>();
		public RequestBlueprint Blueprint { get; set; }
		public bool Completed { get; set; }
	}
}