using UnityEngine;

namespace Platform
{
    public class StickyPlatform : MonoBehaviour
    {
        public string tagName = "Player";

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(tagName))
                collision.transform.SetParent(transform);
        }


        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(tagName))
                if (collision.transform.parent == transform)
                    collision.transform.SetParent(null);
        }
    }
}

