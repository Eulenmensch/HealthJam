using System;
using UnityEngine;

public enum GameState
{
	OnShift,
	OffShift,
	Minigame,
	Lost
}

namespace _Source.Scripts
{
	public class GameManager : MonoBehaviour
	{
		#region Singleton
		public static GameManager Instance { get; private set; }
		private void Awake()
		{
			DontDestroyOnLoad(transform.gameObject);
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

		[field: SerializeField] public PlayerData PlayerData { get; set; }
		[SerializeField] private ShiftData shiftData;

		private GameState gameState = GameState.OnShift;

		private float timer;
		private float energyTickTimer;

		private void Start()
		{
			timer = 0;
			energyTickTimer = 0;
			PlayerData.Energy = PlayerData.maxEnergy;
		}

		private void Update()
		{
			switch (gameState)
			{
				case GameState.OnShift:
					HandleOnShift();
					break;
				case GameState.OffShift:
					HandleOffShift();
					break;
				case GameState.Minigame:
					HandleMinigame();
					break;
				case GameState.Lost:
					HandleGameLost();
					break;
				default:
					Debug.LogError("The GameState is not valid");
					break;
			}
		}

		private void HandleOnShift()
		{
			energyTickTimer += Time.deltaTime;
			if (energyTickTimer >= PlayerData.energyTickRateInSeconds)
			{
				PlayerData.Energy --;
				energyTickTimer = 0;
			}

			timer += Time.deltaTime;

			float remainingTimeInSeconds = shiftData.ShiftDurationInMinutes * 60 - timer;
			UIEvents.Instance.ModifyTimer(remainingTimeInSeconds);
			if (remainingTimeInSeconds <= 0f)
			{
				timer = 0;
				gameState = GameState.OffShift;
				print("gamestate off shift");
			}
		}

		private void HandleOffShift()
		{

		}

		private void HandleMinigame()
		{

		}

		private void HandleGameLost()
		{

		}
	}
}