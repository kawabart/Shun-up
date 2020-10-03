using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CircleSpinner circleSpinner;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying && Input.anyKeyDown)
        {
            PlayGame();
        }
    }

    void PlayGame()
    {
        isPlaying = true;
        circleSpinner.enabled = true;
    }
}
