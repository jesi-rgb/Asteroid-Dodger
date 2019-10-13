using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject fallinBlockPrefab;

    float timer;
    Vector2 screenBoundaries;
    Vector2 difficultyFrequency = new Vector2(.3f, 2f);

    // Start is called before the first frame update
    void Start()
    {
        timer = .5f;
        screenBoundaries = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Vector2 spawnPosition = new Vector3(Random.Range(-screenBoundaries.x + fallinBlockPrefab.transform.localScale.x / 2f, screenBoundaries.x - fallinBlockPrefab.transform.localScale.x / 2f), screenBoundaries.y + fallinBlockPrefab.transform.localScale.y / 2f, 2);

            float secondsSpawn = Mathf.Lerp(difficultyFrequency.y, difficultyFrequency.x, DifficultyManager.getDifficultyPercent());
            timer = secondsSpawn;

            Instantiate(fallinBlockPrefab, spawnPosition, Quaternion.identity).transform.parent = transform;

        }

    }
}
