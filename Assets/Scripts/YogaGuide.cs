using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YogaGuide : MonoBehaviour
{
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject[] trainSlides;
    [SerializeField] private Text currentIndex;

    private int _index = 0;

    private void Start()
    {
        trainSlides[_index].SetActive(true);
    }
    private void Update()
    {
        ArrowDisabling();
        SetText();
    }
    public void Next()
    {
        _index++;
        trainSlides[_index].SetActive(true);
        trainSlides[_index - 1].SetActive(false);
    }
    public void Previous()
    {
        _index--;
        trainSlides[_index].SetActive(true);
        trainSlides[_index + 1].SetActive(false);
    }

    private void ArrowDisabling()
    {
        if (_index == 0)
        {
            _index = 0;
            leftArrow.SetActive(false);
            rightArrow.SetActive(true);
        }
        else if (_index > 0 && _index < trainSlides.Length - 1)
        {
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        else if (_index >= trainSlides.Length - 1)
        {
            leftArrow.SetActive(true);
            rightArrow.SetActive(false);
        }
        //if(_index <= trainSlides.Length - 1 && _index > 0)
        //{
        //    leftArrow.SetActive(true);
        //    rightArrow.SetActive(true);
        //}
    }
    private void SetText()
    {
        currentIndex.text = $"{_index + 1}/{trainSlides.Length}";
    }
}
