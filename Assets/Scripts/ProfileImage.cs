using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProfileImage : MonoBehaviour
{
    public Image profileImage;

    private const string ImagePathKey = "ProfileImagePath";

    void Start()
    {
        if (PlayerPrefs.HasKey(ImagePathKey))
        {
            string savedPath = PlayerPrefs.GetString(ImagePathKey);
            LoadImage(savedPath);
        }
    }

    public void OnButtonClick()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                LoadImage(path);
                SaveImage(path);
            }
        }, "Выберите изображение", "image/*");
    }

    private void LoadImage(string path)
    {
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        profileImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    private void SaveImage(string path)
    {
        PlayerPrefs.SetString(ImagePathKey, path);
    }
}
