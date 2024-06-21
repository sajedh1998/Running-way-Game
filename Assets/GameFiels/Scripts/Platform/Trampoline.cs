using UnityEngine;

namespace Platform
{
    public class Trampoline : MonoBehaviour
    {
        public float jumpForce = 20f;
        private Rigidbody2D playerRb;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerRb = collision.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                }
            }
        }
    }
}