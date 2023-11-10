using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private Image[] _loadingCircles;
    private string _sceneToLoad;

    private void Start()
    {
        _loadingCircles = GetComponentsInChildren<Image>();

        ChooseScene();

        StartCoroutine(LoadApp());
    }

    private IEnumerator LoadApp()
    {
        foreach(Image circle in _loadingCircles)
        {
            yield return new WaitForSeconds(0.7f);
            circle.enabled = true;
            circle.GetComponent<Animator>().SetTrigger("Load");
        }
        Debug.Log("Loaded");

        SceneChanger.instance.FadeLoad(_sceneToLoad);
        //SceneManager.LoadScene(_sceneToLoad);
    }
    private void ChooseScene()
    {
        _sceneToLoad = PlayerPrefs.HasKey("Username") ? "ChooseScene" : "RegistrationScene";
    }
}
