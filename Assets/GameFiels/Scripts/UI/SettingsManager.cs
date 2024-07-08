using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [System.Serializable]
    public class AudioSettings
    {
        public AudioSource audio;
        public bool muted;
    }

    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance;

        public List<AudioSettings> audioSettings;

        private void Awake()
        {
            Instance = this;
            LoadSound();
        }

        private void LoadSound()
        {
            for (int i = 0; i < audioSettings.Count; i++)
            {
                audioSettings[i].muted = PlayerPrefs.GetInt("muted_" + i, 0) == 1;
                audioSettings[i].audio.mute = audioSettings[i].muted;
            }
        }

        public void ToggleMute(int index)
        {
            audioSettings[index].muted = !audioSettings[index].muted;
            audioSettings[index].audio.mute = audioSettings[index].muted;
            SaveSound();
        }

        public bool IsMuted(int index)
        {
            return audioSettings[index].muted;
        }

        private void SaveSound()
        {
            for (int i = 0; i < audioSettings.Count; i++)
            {
                PlayerPrefs.SetInt("muted_" + i, audioSettings[i].muted ? 1 : 0);
            }
            PlayerPrefs.Save();
        }
    }
}
