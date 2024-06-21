using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class FinishLevel : MonoBehaviour
    {
        public bool levelCompleted;
        public string playerName = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject != null)
            {
                if (collision.gameObject.CompareTag(playerName) && !levelCompleted)
                {
                    SoundManager.Instance.PlaySound(3);
                    levelCompleted = true;
                    Invoke(nameof(CompleteLevel), 2f);
                }
            }
        }

        private void CompleteLevel()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(nextSceneIndex);
            else
                Debug.LogWarning("No next scene available.");
        }
    }
}
