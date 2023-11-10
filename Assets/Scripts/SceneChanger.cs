using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator fade;
    public static SceneChanger instance;
    private string _sceneToLoad;
    private void Awake()
    {
        instance = this;
        fade = GetComponent<Animator>();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
    public void FadeLoad(string name)
    {
        fade.SetTrigger("FadeOut");
        _sceneToLoad = name;
    }


    public void LoadYoga()
    {
        PlayerPrefs.SetString("Training", "YogaScene");
        FadeLoad("YogaScene");
    }
    public void LoadMeditation()
    {
        PlayerPrefs.SetString("Training", "MeditationScene");
        FadeLoad("MeditationScene");
    }

    public void LoadMenu()
    {  
        string scene = PlayerPrefs.GetString("Training");
        Debug.Log(scene);
        if(scene == "MeditationScene")
        {
            LoadMeditation();
        }
        else if(scene == "YogaScene")
        {
            LoadYoga();
        }
    }
}
