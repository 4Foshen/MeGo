using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOf : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite offButtonSprite;
    [SerializeField] private Sprite onButtonSprite;
    private bool isOn;

    private void Start()
    {
        isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        SetSprite();
    }

    public void MusicToggle()
    {
        if (isOn)
        {
            buttonImage.sprite = offButtonSprite;
            isOn = false;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            buttonImage.sprite = onButtonSprite;
            isOn = true;
            PlayerPrefs.SetInt("Music", 1);
        }
    }
    private void SetSprite()
    {
        if(isOn)
        {
            buttonImage.sprite = onButtonSprite;
        }
        else
        {
            buttonImage.sprite = offButtonSprite;
        }
    }
}
