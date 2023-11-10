using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFacts : MonoBehaviour
{
    private Text _factsText;
    [SerializeField] private string[] facts;

    private void Awake()
    {
        _factsText = GetComponent<Text>();
    }
    private void Start()
    {
        SetRandomFact();
    }
    private void SetRandomFact()
    {
        int ranNum = Random.Range(0, facts.Length);
        _factsText.text = "Интересный факт:\n" + facts[ranNum];
    }
}
