using UnityEngine;
using UnityEngine.InputSystem;

namespace _Source.Scripts
{
	public class CharacterInteractionController : MonoBehaviour
	{
		[SerializeField] private GameEvent interactedEvent;

		public void GetInteractionInput(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				Interact();
			}
		}

		private void Interact()
		{
			if (interactedEvent == null)
			{
				Debug.LogError("there's no GameEvent asset assigned to this object");
				return;
			}
			interactedEvent.Raise();
		}
	}
}