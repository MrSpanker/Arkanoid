using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private TMP_Text _levelNumber;

    private void OnEnable()
    {
        GameProgress.OnSavesLoad += UpdateDisplays;
        GameProgress.OnProgressUpdated += UpdatePlayerScore;
    }

    private void OnDisable()
    {
        GameProgress.OnSavesLoad -= UpdateDisplays;
        GameProgress.OnProgressUpdated -= UpdatePlayerScore;
    }

    private void UpdateDisplays()
    {
        _levelNumber.text = "Уровень " + (GameProgress.GetCurrentLevelNumber() + 1).ToString();
        UpdatePlayerScore();
    }

    private void UpdatePlayerScore()
    {
        _playerScore.text = "Очки: " + GameProgress.GetPlayerScore().ToString();
    }
}