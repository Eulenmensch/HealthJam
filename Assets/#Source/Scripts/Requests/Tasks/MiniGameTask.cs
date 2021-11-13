using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.Scripts
{
	[CreateAssetMenu]
	public class MiniGameTask : Task
	{
		[SerializeField] private SceneReference minigame;

		void Load()
		{
			SceneManager.LoadSceneAsync(minigame);
		}
	}
}