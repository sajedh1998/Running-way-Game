using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class FinishLevel : MonoBehaviour
    {
        public bool levelCompleted;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name == "Player" && !levelCompleted)
            {
                SoundManager.instance.PlaySound(3);
                levelCompleted = true;

                Invoke("CompleteLevel", 2f);
            }
        }

        private void CompleteLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}