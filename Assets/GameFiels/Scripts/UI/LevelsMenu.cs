using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelsMenu : MonoBehaviour
    {
        public Button[] levelButtons;

        void Start()
        {
            int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevel", 1);

            for (int i = 0; i < levelButtons.Length; i++)
            {
                int levelIndex = i + 1;
                levelButtons[i].interactable = levelIndex <= unlockedLevels;

                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
            }
        }

        public void LoadLevel(int levelIndex)
        {
            print(levelIndex);
            SceneManager.LoadScene(levelIndex);
        }
    }
}