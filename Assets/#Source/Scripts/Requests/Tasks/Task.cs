using UnityEngine;

namespace _Source.Scripts
{
	public abstract class Task : ScriptableObject
	{
		[field: SerializeField] public LocationType destinationType { get; set; }
	}
}