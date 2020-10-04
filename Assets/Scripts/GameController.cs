using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private CircleSpinner circleSpinner;

    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        circleSpinner.DistanceChanged += CheckWin;
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

    void StopGame()
    {
        isPlaying = false;
        circleSpinner.enabled = false;
    }

    void CheckWin()
    {
        bool win = circleSpinner.Distance >= levelManager.GetCurrentLevel().distance;

        if (win)
        {
            StopGame();
            levelManager.GoNextLevel();
        }
    }
}
