using UnityEngine;

namespace _Source.Scripts
{
	[CreateAssetMenu]
	public class ShiftData : ScriptableObject
	{
		[field: SerializeField] public float ShiftDurationInMinutes { get; set; }
	}
}