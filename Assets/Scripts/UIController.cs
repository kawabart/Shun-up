using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI distance;

    [SerializeField]
    CircleSpinner circleSpinner;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDistance();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDistance();
    }

    void UpdateDistance()
    {
        distance.text = $"{circleSpinner.Distance}/10";// {(int)LevelDistance.Level1}";
    }

    void ColorDistance()
    {
        //Color color = new Color()
        //distance.color = 
    }
}
