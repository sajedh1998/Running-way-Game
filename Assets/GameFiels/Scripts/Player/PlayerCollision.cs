using Sound;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private Animator anim;
        private Rigidbody2D rb;

        private bool isFillDown;
        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Trap"))
                Die();
            else if (collision.CompareTag("FillDown"))
            {
                isFillDown = true;
                Die();
            }
        }

        private void Die()
        {
            HealthManager.instance.healthCounter--;
            if (HealthManager.instance.healthCounter <= 0 || isFillDown)
            {
                rb.bodyType = RigidbodyType2D.Static;
                SoundManager.Instance.PlaySound(2);
                anim.SetTrigger("Death");
                Invoke(nameof(EnableReplay), 1.5f);
            }
            else
                StartCoroutine(RePlay());
        }

        IEnumerator RePlay()
        {
            SoundManager.Instance.PlaySound(4);
            anim.SetLayerWeight(1, 1);
            Physics2D.IgnoreLayerCollision(7, 8);
            yield return new WaitForSeconds(2);
            anim.SetLayerWeight(1, 0);
            Physics2D.IgnoreLayerCollision(7, 8, false);
        }

        public void EnableReplay()
        {
            HealthManager.instance.replayPanel.SetActive(true);
        }
    }
}