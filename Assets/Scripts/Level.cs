using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
    public int distance;
    public Sprite circle;
    public GameObject[] obstacles;
}
