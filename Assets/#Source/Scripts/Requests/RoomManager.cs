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
			List<Room> validRooms = new List<Room>();
			foreach (var room in rooms)
			{
				if (room.locationType == locationType && room.Available)
				{
					validRooms.Add(room);
				}
			}

			if (validRooms.Count == 0)
			{
				return null;
			}

			int randomRoomIndex = Random.Range(0, validRooms.Count);
			print(randomRoomIndex);
			return validRooms[randomRoomIndex];
		}

		public void AddRoom(Room room)
		{
			rooms.Add(room);
		}
	}
}