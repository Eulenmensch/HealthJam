using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts
{
	public class RoomManager : MonoBehaviour
	{
		#region Singleton
		public static RoomManager Instance { get; private set; }

		private void Awake()
		{
			if ( Instance != null && Instance != this )
			{
				Destroy( this );
			}
			else
			{
				Instance = this;
			}
		}
		#endregion

		[SerializeField] private List<Room> rooms;

		public Room GetRandomAvailableRoomOfType(LocationType locationType)
		{
			foreach (var room in rooms)
			{
				if (room.locationType == locationType && room.Available)
				{
					return room;
				}
			}
			return null;
		}
	}
}