using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        if (GameProgress.HasMoreLevels())
        {
            GameProgress.NextLevel();
            SceneManager.LoadScene("Game");
        }
        else
        {
            GameProgress.ResetProgress();
            Debug.Log("Все уровни пройдены! Прогресс сброшен.");
            SceneManager.LoadScene("Game");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
