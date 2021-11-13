using System;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace _Source.Scripts
{
	public class Room : MonoBehaviour
	{
		[field: SerializeField] public LocationType locationType { get; set; }
		[SerializeField] private MMFeedbacks alertFeedbacks;

		public bool Available { get; set; }

		private void OnEnable()
		{
			RequestEvents.Instance.OnRoomActivated += ActivateRoom;
			RequestEvents.Instance.OnRoomDeactivated += DeactivateRoom;
		}

		private void OnDisable()
		{
			RequestEvents.Instance.OnRoomActivated -= ActivateRoom;
			RequestEvents.Instance.OnRoomDeactivated -= DeactivateRoom;
		}

		private void Start()
		{
			Available = true;
			RoomManager.Instance.AddRoom(this);
		}

		private void ActivateRoom(Room room)
		{
			if(room == this)
			{
				print(room.name);
				alertFeedbacks.PlayFeedbacks();
				Available = false;
			}
		}

		private void DeactivateRoom(Room room)
		{
			if (room == this)
			{
				Available = true;
			}
		}
	}
}