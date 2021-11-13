using System;
using UnityEngine;

namespace _Source.Scripts
{
	public class UIEvents : MonoBehaviour
	{
		#region Singleton
		public static UIEvents Instance { get; private set; }
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

		public event Action<int> OnModifyEnergy;
		public void ModifyEnergy(int energyAmount){OnModifyEnergy?.Invoke(energyAmount);}

		public event Action<int> OnModifyPraise;
		public void ModifyPraise(int praiseAmount){OnModifyPraise?.Invoke(praiseAmount);}

		public event Action<float> OnModifyTimer;
		public void ModifyTimer(float time){OnModifyTimer?.Invoke(time);}
	}
}