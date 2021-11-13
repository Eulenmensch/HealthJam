using System;
using UnityEngine;

namespace _Source.Scripts
{
	public class TaskChecker : MonoBehaviour
	{
		public Task CurrentTask { get; set; }
		public Guid ParentRequestID { get; set; }
		public bool Completed { get; set; }

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
			RequestEvents.Instance.TaskCompleted(ParentRequestID);
		}
	}
}