using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI distance;

    [SerializeField]
    LevelManager levelManager;
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
        ColorDistance();
    }

    void UpdateDistance()
    {
        distance.text = $"{circleSpinner.Distance}/{levelManager.GetCurrentLevel().distance}";
    }

    void ColorDistance()
    {
        float percentOfDistance = (float)circleSpinner.Distance / (float)levelManager.GetCurrentLevel().distance;
        Color color = new Color(r: Mathf.Clamp01(2f - percentOfDistance * 2), g: Mathf.Clamp01(percentOfDistance * 2), b: 0);
        Debug.Log(color);
        distance.color = color;
    }
}
