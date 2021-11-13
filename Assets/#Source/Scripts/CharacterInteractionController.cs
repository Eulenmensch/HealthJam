using UnityEngine;
using UnityEngine.InputSystem;

namespace _Source.Scripts
{
	public class CharacterInteractionController : MonoBehaviour
	{
		public void GetInteractionInput(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				print("interact");
				Interact();
			}
		}

		private void Interact()
		{
			PlayerEvents.Instance.Interact();
		}
	}
}