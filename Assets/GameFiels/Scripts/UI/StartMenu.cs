using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartMenu : MonoBehaviour
    {
        public Button startButton;

        private void Awake()
        {
            startButton.onClick.AddListener(PlayGame);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}