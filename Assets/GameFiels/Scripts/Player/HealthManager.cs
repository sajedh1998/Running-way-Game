using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        public static HealthManager instance;

        public int healthCounter;
        public Image[] playerHealth;
        public Sprite fillHeart;
        public Sprite emptyHeart;
        public GameObject replayPanel;

        private void Awake()
        {
            instance = this;
            healthCounter = 3;
        }

        private void Update()
        {
            foreach (Image img in playerHealth)
                img.sprite = emptyHeart;

            for (int i = 0; i < healthCounter; i++)
                playerHealth[i].sprite = fillHeart;
        }
    }
}
