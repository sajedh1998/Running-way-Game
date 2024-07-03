using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class FinishLevel : MonoBehaviour
    {
        public bool levelCompleted;
        public string playerName = "Player";
        int nextSceneIndex;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject != null)
            {
                if (collision.gameObject.CompareTag(playerName) && !levelCompleted)
                {
                    nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    SoundManager.Instance.PlaySound(3);
                    levelCompleted = true;
                    UnlockNewLevel();
                    Invoke(nameof(LoadNextLevel), 1);
                }
            }
        }

        void LoadNextLevel()
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        private void UnlockNewLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int highestUnlockedLevel = PlayerPrefs.GetInt("ReachedIndex", 1);

            if (currentSceneIndex >= highestUnlockedLevel)
            {
                PlayerPrefs.SetInt("ReachedIndex", nextSceneIndex);
                PlayerPrefs.Save();
            }
        }

    }
}
