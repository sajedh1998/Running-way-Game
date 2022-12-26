using UnityEngine;
using Sound;
namespace Player
{
    [System.Serializable]

    public enum MovementState
    {
        idle, running, jumping, filling
    }

    public class PlayerMovement : MonoBehaviour
    {
        PlayerControl controls;
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 14f;
        [SerializeField] private LayerMask jumbableGround;
        [SerializeField] private SoundManager soundEffect;
        private BoxCollider2D collider;
        private Rigidbody2D playerRb;
        private SpriteRenderer playerSprite;
        private Animator playerAnim;
        private string stateName = "state";
        private string key = "Jump";
        private string direction = "Horizontal";
        private float dirX = 0;
        MovementState state;


        private void Awake()
        {
            controls = new PlayerControl();
            controls.Enable();
            controls.Ground.Move.performed += ctx =>
            {
                dirX = ctx.ReadValue<float>();
            };

            controls.Ground.Jump.performed += ctx => Jump();
        }

        private void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();
            playerSprite = GetComponent<SpriteRenderer>();
            collider = GetComponent<BoxCollider2D>();
            playerAnim = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            playerRb.velocity = new Vector2(dirX * moveSpeed, playerRb.velocity.y);
            UpdateAnimationState();
        }

        public void UpdateAnimationState()
        {
            if (dirX > 0f)
            {
                state = MovementState.running;
                playerSprite.flipX = false;
            }

            else if (dirX < 0f)
            {
                state = MovementState.running;
                playerSprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            if (playerRb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }

            else if (playerRb.velocity.y < -.1f)
            {
                state = MovementState.filling;
            }

            playerAnim.SetInteger(stateName, (int)state);
        }
        void Jump()
        {
            if (IsGrounded())
            {
                soundEffect.PlaySound(0);
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(collider.bounds.center,
                collider.bounds.size, 0f,
                Vector2.down, 0.1f,
                jumbableGround);
        }

    }
}