using System;
using UnityEngine;

namespace _Source.Scripts
{
	public class RequestEvents : MonoBehaviour
	{
		#region Singleton
		public static RequestEvents Instance { get; private set; }

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

		public event Action<Guid> OnTaskCompleted;
		public void TaskCompleted(Guid parentRequestID){OnTaskCompleted?.Invoke(parentRequestID);}

		public event Action<RequestBlueprint> OnRequestCompleted;
		public void RequestCompleted(RequestBlueprint blueprint){OnRequestCompleted?.Invoke(blueprint);}

		public event Action<Room> OnRoomActivated;
		public void RoomActivated(Room room){OnRoomActivated?.Invoke(room);}
		public event Action<Room> OnRoomDeactivated;
		public void RoomDeactivated(Room room){OnRoomDeactivated?.Invoke(room);}
	}
}