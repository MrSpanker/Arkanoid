using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameProgress
{
    private static int _currentLevel = 0;
    private static List<LevelData> _levels;

    static GameProgress()
    {
        LoadLevels();
    }

    public static int GetCurrentLevelNumber()
    {
        return _currentLevel;
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
        PlayerPrefs.Save();
    }

    public static void LoadProgress()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
    }

    public static void ResetProgress()
    {
        _currentLevel = 0;
        SaveProgress();
    }
}
