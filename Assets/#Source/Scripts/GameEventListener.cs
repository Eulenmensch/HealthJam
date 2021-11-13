using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Source.Scripts
{
	public class GameEventListener : MonoBehaviour
	{
		[Tooltip("Event to register with")]
		[SerializeField] private GameEvent gameEvent;

		[Tooltip("Response to invoke when the Event is Raised")]
		[SerializeField] private UnityEvent response;

		private void OnEnable()
		{
			gameEvent.RegisterListener(this);
		}

		private void OnDisable()
		{
			gameEvent.UnregisterListener(this);
		}

		public void OnEventRaised()
		{
			response.Invoke();
		}
	}
}