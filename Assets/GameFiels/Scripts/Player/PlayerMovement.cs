using UnityEngine;
using Sound;

namespace Player
{
    [System.Serializable]
    public enum MovementState
    {
        Idle, Running, Jumping, Falling
    }

    public class PlayerMovement : MonoBehaviour
    {
        private PlayerControl controls;
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 14f;
        [SerializeField] private LayerMask jumpableGround;

        private BoxCollider2D boxCollider;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        private float directionX = 0f;
        private MovementState state;
        private const string StateName = "state";

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();

            controls = new PlayerControl();
            controls.Enable();

            controls.Ground.Move.performed += ctx => directionX = ctx.ReadValue<float>();
            controls.Ground.Jump.performed += ctx => Jump();

        }

        private void FixedUpdate()
        {
            Move();
            UpdateAnimationState();
        }

        private void Move()
        {
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        }

        private void UpdateAnimationState()
        {
            if (directionX > 0f)
            {
                state = MovementState.Running;
                spriteRenderer.flipX = false;
            }
            else if (directionX < 0f)
            {
                state = MovementState.Running;
                spriteRenderer.flipX = true;
            }
            else
            {
                state = MovementState.Idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.Jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.Falling;
            }

            animator.SetInteger(StateName, (int)state);
        }

        private void Jump()
        {
            if (IsGrounded())
            {
                SoundManager.Instance.PlaySound(0);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        private bool IsGrounded()
        {
            if (boxCollider != null)
                return Physics2D.BoxCast(boxCollider.bounds.center,
                                         boxCollider.bounds.size,
                                         0f,
                                         Vector2.down,
                                         0.1f,
                                         jumpableGround);

            else return false;
        }
    }
}
