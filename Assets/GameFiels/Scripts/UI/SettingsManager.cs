using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [System.Serializable]

    public class AudioSettings
    {
        public AudioSource audio;
        public Button soundButton;
        public Image onSound;
        public Image offSound;
        public bool muted;
    }

    public class SettingsManager : MonoBehaviour
    {
        public List<AudioSettings> audioSettings;
        public Button closeButton;
        public Button homeButton;
        public int index;

        private void Start()
        {
            if (!PlayerPrefs.HasKey("muted"))
            {
                PlayerPrefs.SetInt("muted", 0);
                LoadSound();
            }
            else
            {
                LoadSound();
            }
        }

        private void Awake()
        {
            closeButton.onClick.AddListener(ClosePanel);
            homeButton.onClick.AddListener(GoHome);
            audioSettings[0].soundButton.onClick.AddListener(delegate { OnButtonPress(0); });
            audioSettings[1].soundButton.onClick.AddListener(delegate { OnButtonPress(1); });
        }

        public void OnButtonPress(int arrIndex)
        {
            if (!audioSettings[arrIndex].muted)
            {
                audioSettings[arrIndex].muted = true;
                audioSettings[arrIndex].audio.mute = true;
            }
            else
            {
                audioSettings[arrIndex].muted = false;
                audioSettings[arrIndex].audio.mute = false;
            }
            SaveDate();
            UpdateButtonIcon(arrIndex);
        }

        private void LoadSound()
        {
            for (int i = 0; i < audioSettings.Count; i++)
            {
                if (i > audioSettings.Count) return;
                audioSettings[i].muted = PlayerPrefs.GetInt("muted") == 1;
            }
        }

        private void SaveDate()
        {
            for (int i = 0; i < audioSettings.Count; i++)
            {
                if (i > audioSettings.Count) return;
                PlayerPrefs.SetInt("muted", audioSettings[i].muted ? 1 : 0);
            }
        }

        private void UpdateButtonIcon(int index)
        {
            if (!audioSettings[index].muted)
            {
                audioSettings[index].onSound.enabled = true;
                audioSettings[index].offSound.enabled = false;
            }
            else
            {
                audioSettings[index].onSound.enabled = false;
                audioSettings[index].offSound.enabled = true;
            }
        }

        public void ClosePanel()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - index);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
