using System;
using UnityEngine;

namespace _Source.Scripts
{
	public class TaskChecker : MonoBehaviour
	{
		public Task CurrentTask { get; set; }
		public Guid ParentRequestID { get; set; }
		public bool Completed { get; private set; }

		private bool playerInTrigger;

		private void OnEnable()
		{
			PlayerEvents.Instance.OnInteract += TaskCompleted;
		}

		private void OnDisable()
		{
			PlayerEvents.Instance.OnInteract -= TaskCompleted;
		}

		public void TaskCompleted()
		{
			if (playerInTrigger)
			{
				Completed = true;
				RequestEvents.Instance.TaskCompleted(ParentRequestID);
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag.Equals("Player"))
			{
				print("triggered");
				playerInTrigger = true;
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.tag.Equals("Player"))
			{
				playerInTrigger = false;
			}
		}
	}
}