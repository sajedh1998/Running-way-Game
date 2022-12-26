using Sound;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Player
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField] private string collisionTag = "Trap";
        [SerializeField] private Image[] playerHealth;
        [SerializeField] private Sprite fillHeart;
        [SerializeField] private Sprite emptyHeart;
        [SerializeField] private GameObject replayPanel;
        [SerializeField] private int healthCounter;
        private Animator anim;
        private Rigidbody2D rb;

        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Awake()
        {
            healthCounter = 3;
        }

        private void Update()
        {
            foreach (Image img in playerHealth)
            {
                img.sprite = emptyHeart;
            }
            for (int i = 0; i < healthCounter; i++)
            {
                playerHealth[i].sprite = fillHeart;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(collisionTag))
            {
                if (gameObject != null)
                {
                    Die();
                }
            }
        }

        private void Die()
        {
            healthCounter--;
            if (healthCounter <= 0)
            {
                rb.bodyType = RigidbodyType2D.Static;
                SoundManager.instance.PlaySound(2);
                anim.SetTrigger("Death");
                Invoke("EnableReplay", 1.5f);
            }

            else 
            {
                StartCoroutine(RePlay());
            }
        }

        IEnumerator RePlay()
        {
            SoundManager.instance.PlaySound(4);
            anim.SetLayerWeight(1, 1);
            Physics2D.IgnoreLayerCollision(7, 8);
            yield return new WaitForSeconds(2);
            anim.SetLayerWeight(1, 0);
            Physics2D.IgnoreLayerCollision(7, 8, false);
        }

        public void EnableReplay()
        {
            replayPanel.SetActive(true);
        }

    }
}
