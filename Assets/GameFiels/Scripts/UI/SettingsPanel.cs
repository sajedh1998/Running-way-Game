using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsPanel : MonoBehaviour
    {
        public GameObject settingsPanel;
        public Button settingButton;

        private void Awake()
        {
            settingButton.onClick.AddListener(OpenSettings);
        }

        public void OpenSettings()
        {
            settingsPanel.SetActive(true);
            settingButton.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
}