using System.Collections.Generic;

namespace _Source.Scripts
{
	public class Request
	{
		public Request(RequestBlueprint blueprint)
		{
			Blueprint = blueprint;
		}

		public List<TaskChecker> OwnTaskCheckers { get; set; } = new List<TaskChecker>();
		public RequestBlueprint Blueprint { get; set; }
	}
}