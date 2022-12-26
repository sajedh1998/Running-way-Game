using Sound;
using TMPro;
using UnityEngine;

namespace Items
{
    public class ItemCollaction : MonoBehaviour
    {
        [SerializeField] private string collisionTag = "Strewbarry";
        [SerializeField] private TextMeshProUGUI strewbarriesCounterText;
        [SerializeField] private AudioSource itemSoundEffect;
        private int strewbarries = 0;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(collisionTag))
            {
                SoundManager.instance.PlaySound(1);
                Destroy(collision.gameObject);
                strewbarries++;
                strewbarriesCounterText.text = "Strewbarry: " + strewbarries.ToString();
            }
        }
    }
}