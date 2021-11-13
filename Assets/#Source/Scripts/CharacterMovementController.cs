using UnityEngine.InputSystem;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbodyReference;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("walking", true);
        }
        if (context.canceled)
        {
            animator.SetBool("walking", false);
        }

        Vector2 inputVector = context.ReadValue<Vector2>();
        Move(inputVector);
        FlipSprite(inputVector);
    }

    private void Move(Vector2 inputVector)
    {
        Vector2 movementDirection = new Vector2(inputVector.x, 0);
        rigidbodyReference.velocity = movementDirection * speed;
    }

    private void FlipSprite(Vector2 inputVector)
    {
        if (inputVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (inputVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
