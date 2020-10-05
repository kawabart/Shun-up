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
    [SerializeField]
    private ObstacleGenerator obstacleGenerator;

    private bool isPlaying = false;
    private bool gameStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        circleSpinner.DistanceChanged += CheckWin;
        guyController.Death += () => StartCoroutine(Lose());
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
        obstacleGenerator.enabled = true;
    }

    void StopGame()
    {
        gameStopped = true;
        isPlaying = false;
        circleSpinner.enabled = false;
        obstacleGenerator.enabled = false;
    }

    void CheckWin()
    {
        bool win = circleSpinner.Distance >= levelManager.GetCurrentLevel().distance;

        if (win)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        StopGame();
        yield return guyController.PlayLevelChangeSequence();

        if (levelManager.GoNextLevel())
            gameStopped = false;
        //else
            //It was last level
    }

    IEnumerator Lose()
    {
        StopGame();
        yield return guyController.PlayDeathSequence();

        circleSpinner.ResetCircle();
        gameStopped = false;
    }
}
