using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private CircleSpinner circleSpinner;
    [SerializeField]
    private GuyController guyController;

    private bool isPlaying = false;
    private bool gameStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        circleSpinner.DistanceChanged += () => StartCoroutine(CheckWin());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStopped && !isPlaying && Input.anyKeyDown)
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
        gameStopped = true;
        isPlaying = false;
        circleSpinner.enabled = false;
    }

    IEnumerator CheckWin()
    {
        bool win = circleSpinner.Distance >= levelManager.GetCurrentLevel().distance;

        if (win)
        {
            StopGame();
            yield return guyController.PlayLevelChangeSequence();
            
            if (levelManager.GoNextLevel())
                gameStopped = false;
            //else
                //It was last level
        }
    }
}
