using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileData : MonoBehaviour
{
    [SerializeField] private Text usernameText;
    [SerializeField] private Text progressText;
    private int _progress;

    private string _username;


    [Header("Level")]
    [SerializeField] private Slider expBar;
    [SerializeField] private Text levelText;
    private int _level = 0;
    private int _currentExp;
    private int _remExp;

    private void Awake()
    {
        LoadData();
    }
    private void Start()
    {
        CalculateLevel();
        SetExpBar();
        SetText();
    }

    private void SetText()
    {
        usernameText.text = _username;
        progressText.text = $"{_progress} тренировок!";
        levelText.text = $"{_level} уровень";
    }
    private void LoadData()
    {
        _progress = PlayerPrefs.GetInt("Progress", 0);
        _username = PlayerPrefs.GetString("Username");
        _currentExp = PlayerPrefs.GetInt("Experience");
    }
    private void CalculateLevel()
    {
        if (_currentExp >= 100)
        {
            _level = _currentExp / 100;
            _remExp = _currentExp % 100;
        }
        else
        {
            _level = 0;
        }
    }
    private void SetExpBar()
    {
        expBar.maxValue = 100;
        expBar.value = _remExp;
    }
}
