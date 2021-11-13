using UnityEngine.InputSystem;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbodyReference;

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        Move(inputVector);
    }

    private void Move(Vector2 inputVector)
    {
        Vector2 movementDirection = new Vector2(inputVector.x, 0);
        rigidbodyReference.velocity = movementDirection * speed;
    }
}
