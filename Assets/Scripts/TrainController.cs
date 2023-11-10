using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] private GameObject[] trainScreens;
    private int screenIndex = 0;

    public void NextTrain()
    {
        screenIndex += 1;
        trainScreens[screenIndex].gameObject.SetActive(true);
        trainScreens[screenIndex - 1].gameObject.SetActive(false);
    }
    public void EndTrain()
    {
        int currentProgress = PlayerPrefs.GetInt("Progress", 0) + 1;
        int currentExp = PlayerPrefs.GetInt("Experience", 0);
        currentExp += 25;

        PlayerPrefs.SetInt("Experience", currentExp);
        PlayerPrefs.SetInt("Progress", currentProgress);
        PlayerPrefs.Save();

        SceneChanger.instance.LoadMenu();
    }
}
