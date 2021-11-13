using System;
using UnityEngine;

namespace _Source.Scripts
{
	public class GameEvents : MonoBehaviour
	{
		#region Singleton
		public static GameEvents Instance { get; private set; }
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

		public event Action OnGameLost;
		public void GameLost(){OnGameLost?.Invoke();}

		public event Action OnPraiseFull;
		public void PraiseFull(){OnPraiseFull?.Invoke();}
	}
}