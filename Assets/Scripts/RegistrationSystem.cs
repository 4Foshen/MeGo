using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegistrationSystem : MonoBehaviour
{
    [SerializeField] private Button regButton;
    private string _username;
    private InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponent<InputField>();
    }
    private void Update()
    {
        CheckButton();
    }
    public void Register()
    {
        _username = _inputField.text;
        Debug.Log(_username);
    }
    public void ApplyRegistration()
    {
        PlayerPrefs.SetString("Username", _username);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("Username"));
        SceneChanger.instance.FadeLoad("ChooseScene");
    }
    private void CheckButton()
    {
        if(_username != null && _username.Length >= 2)
        {
            regButton.interactable = true;
        }
        else
        {
            regButton.interactable = false;
        }
    }
}
