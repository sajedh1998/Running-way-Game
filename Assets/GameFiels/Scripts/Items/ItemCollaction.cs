using Sound;
using UnityEngine;

namespace Items
{
    public class ItemCollaction : MonoBehaviour
    {
        [SerializeField] private string collisionWithTag = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag(collisionWithTag))
            {
                PlayerManager.instance.coins++;
                PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.instance.coins);
                SoundManager.Instance.PlaySound(1);
                Destroy(gameObject);
            }
        }
    }
}