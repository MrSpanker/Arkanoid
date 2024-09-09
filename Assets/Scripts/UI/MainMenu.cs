using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }
    
    public void CloseSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
