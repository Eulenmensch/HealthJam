using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts
{
	public class EnergyBarBehaviour : MonoBehaviour
	{
		[SerializeField] private Image energy;
		private PlayerData playerData;
		[SerializeField] private Gradient energyGradient;


		private void OnEnable()
		{
			UIEvents.Instance.OnModifyEnergy += SetEnergyBarAmount;
		}

		private void OnDisable()
		{
			UIEvents.Instance.OnModifyEnergy -= SetEnergyBarAmount;
		}

		private void Awake()
		{
			playerData = GameManager.Instance.PlayerData;
			print(playerData.name);
		}

		private void SetEnergyBarAmount(int amount)
		{
			energy.fillAmount = (float)amount / playerData.maxEnergy;
			energy.color = energyGradient.Evaluate(energy.fillAmount);
		}
	}
}