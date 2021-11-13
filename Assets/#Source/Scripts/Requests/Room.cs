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

		private void ActivateRoom()
		{
			alertFeedbacks.PlayFeedbacks();
			Available = false;
		}

		private void DeactivateRoom()
		{
			Available = true;
		}
	}
}