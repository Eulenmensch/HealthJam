using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts
{
	[CreateAssetMenu]
	public class GameEvent : ScriptableObject
	{
		private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

		public void Raise()
		{
			foreach (var eventListener in eventListeners)
			{
				eventListener.OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			if (!eventListeners.Contains(listener))
			{
				eventListeners.Add(listener);
			}
		}

		public void UnregisterListener(GameEventListener listener)
		{
			if (eventListeners.Contains(listener))
			{
				eventListeners.Remove(listener);
			}
		}
	}
}