using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevel = 0;
    [SerializeField]
    private Level[] levels;
    
    public Level GetCurrentLevel()
    {
        return levels[currentLevel];
    }

    public void GoNextLevel()
    {
        currentLevel++;

        if (currentLevel >= levels.Length)
            currentLevel = levels.Length - 1;
    }

    public void GoPreviousLevel()
    {
        currentLevel--;

        if (currentLevel < 0)
            currentLevel = 0;
    }
}
