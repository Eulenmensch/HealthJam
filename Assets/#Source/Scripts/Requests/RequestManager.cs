using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Scripts
{
	public class RequestManager : MonoBehaviour
	{
		#region Singleton
		public static RequestManager Instance { get; private set; }

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

		[SerializeField] private List<RequestBlueprint> requests = new List<RequestBlueprint>();

		private Dictionary<Guid, Request> activeRequestsDictionary;

		private void OnEnable()
		{
			RequestEvents.Instance.OnTaskCompleted += CompleteTask;
		}

		private void OnDisable()
		{
			RequestEvents.Instance.OnTaskCompleted -= CompleteTask;
		}

		public void SelectRandomRequest()
		{
			int randomIndex = Random.Range(0, requests.Count - 1);
			RequestBlueprint selectedRequestBlueprint = requests[randomIndex];
			Request request = new Request(selectedRequestBlueprint, false);

			Guid requestID = new Guid();
			activeRequestsDictionary.Add(requestID, request);

			foreach (var task in selectedRequestBlueprint.Tasks)
			{
				var room = RoomManager.Instance.GetRandomAvailableRoomOfType(task.destinationType);
				if (room == null) return;
				RequestEvents.Instance.RoomActivated();

				TaskChecker taskChecker = room.AddComponent<TaskChecker>();
				taskChecker.ParentRequestID = requestID;
				request.OwnTaskCheckers.Add(taskChecker);
			}
		}

		private void CompleteTask(Guid parentRequestID)
		{
			Request parentRequest = activeRequestsDictionary[parentRequestID];
			foreach (var taskChecker in parentRequest.OwnTaskCheckers)
			{
				if (!taskChecker.Completed)
				{
					return;
				}
				Destroy(taskChecker); //TODO: not sure if this ruins the for loop
			}
			parentRequest.Completed = true;
			RequestEvents.Instance.RequestCompleted(parentRequest.Blueprint); //TODO: the praise bar needs to subscribe to this
			RequestEvents.Instance.RoomDeactivated();
		}
	}
}