using UnityEngine;

namespace _Source.Scripts
{
	[CreateAssetMenu]
	public class PlayerData : ScriptableObject
	{
		[field: SerializeField] public int maxEnergy { get; set; }
		[SerializeField] private int energy;
		public int Energy
		{
			get => energy;
			set
			{
				if (value > maxEnergy)
				{
					energy = maxEnergy;
				}
				else if (value <= 0)
				{
					energy = 0;
					GameEvents.Instance.GameLost();
				}
				else
				{
					energy = value;
				}
				UIEvents.Instance.ModifyEnergy(energy);
			}
		}

		[field: SerializeField] public float energyTickRateInSeconds { get; set; }

		[SerializeField] private int maxPraise;
		[SerializeField] private int praise;
		public int Praise
		{
			get => praise;
			set
			{
				praise = value;
				if (praise > maxPraise)
				{
					praise = 0;
					GameEvents.Instance.PraiseFull();
				}
				UIEvents.Instance.ModifyPraise(praise);
			}
		}

		private Vector3 location;
	}
}