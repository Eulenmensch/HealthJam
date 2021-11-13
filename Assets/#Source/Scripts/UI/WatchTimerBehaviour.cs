using System;
using TMPro;
using UnityEngine;

namespace _Source.Scripts
{
	public class WatchTimerBehaviour : MonoBehaviour
	{
		[SerializeField] private TMP_Text text;
		[SerializeField] private float timeMultiplier;

		private void OnEnable()
		{
			UIEvents.Instance.OnModifyTimer += UpdateWatchTimer;
		}

		private void OnDisable()
		{
			UIEvents.Instance.OnModifyTimer -= UpdateWatchTimer;
		}

		private void UpdateWatchTimer(float time)
		{
			float fakeTime = time * timeMultiplier;
			TimeSpan formattedTime = TimeSpan.FromSeconds(fakeTime);
			string timerString = formattedTime.ToString(@"hh\:mm");
			text.text = timerString;
		}
	}
}