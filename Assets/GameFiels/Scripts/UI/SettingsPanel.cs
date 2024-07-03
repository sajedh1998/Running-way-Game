using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SettingsPanel : MonoBehaviour
    {
        public GameObject settingsPanel;
        public Button closeButton;
        public Button homeButton;
        public Button[] soundButtons;
        public Image[] onSoundIcons;
        public Image[] offSoundIcons;

        public int index;

        private void Start()
        {
            closeButton.onClick.AddListener(ClosePanel);
            homeButton.onClick.AddListener(GoHome);
            for (int i = 0; i < soundButtons.Length; i++)
            {
                int index = i;
                soundButtons[i].onClick.AddListener(() => ToggleSound(index));
            }
            UpdateButtonIcons();
        }

        private void ToggleSound(int index)
        {
            SettingsManager.Instance.ToggleMute(index);
            UpdateButtonIcon(index);
        }

        private void UpdateButtonIcon(int index)
        {
            bool muted = SettingsManager.Instance.IsMuted(index);
            onSoundIcons[index].enabled = !muted;
            offSoundIcons[index].enabled = muted;
        }

        private void UpdateButtonIcons()
        {
            for (int i = 0; i < soundButtons.Length; i++)
            {
                UpdateButtonIcon(i);
            }
        }

        public void OpenPanel()
        {
            settingsPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            settingsPanel.SetActive(false);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(index);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
