using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ReplayPanel : MonoBehaviour
    {
        [SerializeField] Button replayButton;
        [SerializeField] Button quitButton;


        private void Awake()
        {
            replayButton.onClick.AddListener(RestartLevel);
            quitButton.onClick.AddListener(QuitGame);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}