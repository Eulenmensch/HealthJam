using System;
using UnityEngine;

namespace _Source.Scripts
{
	public class PlayerEvents : MonoBehaviour
	{
		#region Singleton
		public static PlayerEvents Instance { get; private set; }

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

		public event Action OnInteract;
		public void Interact() {OnInteract?.Invoke();}
	}
}