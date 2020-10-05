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

    private void OnEnable()
    {
        obstaclePrefabs = levelManager.GetCurrentLevel().obstacles;
        StartCoroutine(GenerateObstacle(2f));
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
