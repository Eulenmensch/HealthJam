using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts
{
	[CreateAssetMenu]
	public class RequestBlueprint : ScriptableObject
	{
		[field: SerializeField] public List<Task> Tasks { get; set; } = new List<Task>();
		[field: SerializeField] public int PraiseAmount { get; set; }
	}
}