using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public static class GameProgress
{
    public static event UnityAction OnProgressUpdated;
    public static event UnityAction OnSavesLoad;

    private static int _currentLevel = 0;
    private static int _playerScore = 0;
    private static List<LevelData> _levels;

    static GameProgress()
    {
        LoadLevels();
    }

    public static int GetCurrentLevelNumber()
    {
        return _currentLevel;
    }

    public static int GetPlayerScore()
    {
        return _playerScore;
    }

    public static bool HasMoreLevels()
    {
        return (_currentLevel < _levels.Count);
    }

    public static LevelData GetCurrentLevelData()
    {
        if (_levels == null || _levels.Count == 0)
        {
            Debug.LogError("Не удалось загрузить уровни.");
            return null;
        }

        if (_currentLevel < _levels.Count)
        {
            return _levels[_currentLevel];
        }
        else
        {
            Debug.LogError("Уровень с данным индексом отсутствует.");
            return null;
        }
    }

    public static void NextLevel()
    {
        _currentLevel++;
        SaveProgress();
    }

    public static void AddScore()
    {
        _playerScore += 15;
        SaveProgress();
    }

    private static void LoadLevels()
    {
        _levels = new List<LevelData>(Resources.LoadAll<LevelData>("Levels"));

        if (_levels.Count == 0)
        {
            Debug.LogError("Уровни не найдены в папке Resources/Levels.");
        }
    }

    private static void SaveProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
        PlayerPrefs.SetInt("PlayerScore", _playerScore);
        PlayerPrefs.Save();
        OnProgressUpdated?.Invoke();
    }

    public static void LoadProgress()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        _playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        Debug.Log("Загружен прогресс: \tУровень - " +  _currentLevel + "\tОчков - " + _playerScore);
        OnSavesLoad?.Invoke();
    }

    public static void ResetProgress()
    {
        _currentLevel = 0;
        _playerScore = 0;
        SaveProgress();
    }
}
