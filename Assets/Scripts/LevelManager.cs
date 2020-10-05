using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action LevelChanged;

    private int currentLevel = 0;
    [SerializeField]
    private Level[] levels;
    
    public Level GetCurrentLevel()
    {
        return levels[currentLevel];
    }

    public bool GoNextLevel()
    {
        currentLevel++;

        if (currentLevel >= levels.Length)
        {
            currentLevel = levels.Length - 1;
            return false;
        }
        else
        {
            LevelChanged.Invoke();
            return true;
        }
    }

    public void GoPreviousLevel()
    {
        currentLevel--;

        if (currentLevel < 0)
            currentLevel = 0;
        else
            LevelChanged.Invoke();
    }
}
