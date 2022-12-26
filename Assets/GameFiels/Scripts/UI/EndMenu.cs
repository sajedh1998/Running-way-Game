using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndMenu : MonoBehaviour
    {
        public Button homeButton;
        public Button quitButton;

        private void Awake()
        {
            homeButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }

        public void QuitGame()
        {
            Application.Quit();

        }
    }
}