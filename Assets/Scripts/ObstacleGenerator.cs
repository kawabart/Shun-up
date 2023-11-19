using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform circle;
    [SerializeField]
    private LevelManager levelManager;

    private GameObject[] obstaclePrefabs;
    private IEnumerator coroutine;

    private void OnEnable()
    {
        obstaclePrefabs = levelManager.GetCurrentLevel().obstacles;
        coroutine = GenerateObstacle(2f);
        StartCoroutine(coroutine);
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator GenerateObstacle(float interval)
    {
        while (enabled)
        {
            if (obstaclePrefabs.Length == 0)
                yield break;

            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            GameObject obstacle = Instantiate(obstaclePrefab, parent: transform);
            obstacle.GetComponent<Obstacle>().target = circle;

            yield return new WaitForSeconds(interval);
        }
    }
}
