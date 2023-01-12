using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject m_Menu;
    public Button m_SettingsToggleButton;
    public Button m_CloseSettingsButton;
    public Toggle m_MusicToggle;

    // Start is called before the first frame update
    void Start()
    {
        m_SettingsToggleButton.onClick.AddListener(ToggleSettings);
        m_CloseSettingsButton.onClick.AddListener(ToggleSettings);
        m_MusicToggle.onValueChanged.AddListener(delegate { OnMusicToggleClicked(); });
    }

    void ToggleSettings() {
        m_Menu.SetActive(!m_Menu.activeSelf);
    }

    void OnMusicToggleClicked() {
        AudioListener.volume = m_MusicToggle.isOn ? 1 : 0;
    }
}
