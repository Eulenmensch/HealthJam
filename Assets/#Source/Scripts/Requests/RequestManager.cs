using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
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

		private Dictionary<Guid, Request> activeRequestsDictionary = new Dictionary<Guid, Request>();

		private void OnEnable()
		{
			RequestEvents.Instance.OnTaskCompleted += CompleteTask;
		}

		private void OnDisable()
		{
			RequestEvents.Instance.OnTaskCompleted -= CompleteTask;
		}

		[Button]
		public void SelectRandomRequest()
		{
			int randomIndex = Random.Range(0, requests.Count);
			RequestBlueprint selectedRequestBlueprint = requests[randomIndex];
			Request request = new Request(selectedRequestBlueprint);

			Guid requestID = Guid.NewGuid();
			print(requestID.ToString());
			print(request.Blueprint.name);
			activeRequestsDictionary.Add(requestID, request);

			foreach (var task in selectedRequestBlueprint.Tasks)
			{
				print(task.name);
				var room = RoomManager.Instance.GetRandomAvailableRoomOfType(task.destinationType);
				if (room == null) return;
				RequestEvents.Instance.RoomActivated(room);

				TaskChecker taskChecker = room.AddComponent<TaskChecker>();
				taskChecker.ParentRequestID = requestID;
				request.OwnTaskCheckers.Add(taskChecker);
			}
		}

		private void CompleteTask(Guid parentRequestID)
		{
			print("completing Task");
			Request parentRequest = activeRequestsDictionary[parentRequestID];
			foreach (var taskChecker in parentRequest.OwnTaskCheckers.ToList())
			{
				if (!taskChecker.Completed)
				{
					continue;
				}

				Room currentRoom = taskChecker.GetComponent<Room>();
				RequestEvents.Instance.RoomDeactivated(currentRoom);
				parentRequest.OwnTaskCheckers.Remove(taskChecker);
				Destroy(taskChecker); //TODO: not sure if this ruins the for loop
			}
			
			RequestEvents.Instance.RequestCompleted(parentRequest.Blueprint); //TODO: the praise bar needs to subscribe to this
		}
	}
}