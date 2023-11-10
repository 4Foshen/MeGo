using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TrainController trainController;

    [SerializeField] private float timerDuration = 2f * 60f;

    private float timer;

    private bool isTimer;

    public Text firstMinute;
    public Text secondMinute;

    public Text firstSecond;
    public Text secondSecond;

    private void OnEnable()
    {
        timer = timerDuration;
        isTimer = true;
    }
    private void Update()
    {
        if (isTimer && timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimer(timer);
        }
        else
        {
            TimerEnd();
        }
    }
    private void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{01:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }
    private void OnDisable()
    {
        isTimer = false;
    }

    private void TimerEnd()
    {
        trainController.NextTrain();
    }
}
