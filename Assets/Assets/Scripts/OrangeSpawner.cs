using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawner : MonoBehaviour
{
    public GameObject OrangePrefab; 
    public List<Transform> spawnPoints;
    public float initialSpawnTime = 2f; 
    private float currentSpawnTime;
    private float targetSpawnTime;
    private bool isSpawning = true;

    void Start()
    {
        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Точки появления не назначены!");
            return;
        }
        currentSpawnTime = initialSpawnTime;
        targetSpawnTime = currentSpawnTime;
        StartCoroutine(SpawnOranges());
    }

    IEnumerator SpawnOranges()
    {
        while (isSpawning) 
        {
            yield return new WaitForSeconds(currentSpawnTime);
            SpawnOrange();
        }
    }
    void Update()
    {
        currentSpawnTime = Mathf.Lerp(currentSpawnTime, targetSpawnTime, Time.deltaTime * 2f);
    }

    void SpawnOrange()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[spawnPointIndex];
        GameObject orange = Instantiate(OrangePrefab, spawnPoint.position, spawnPoint.rotation);
        OrangeMovement orangeMovement = orange.GetComponent<OrangeMovement>();
        if (orangeMovement != null)
        {
            orangeMovement.SetSpeed(2f);
        }
    }
    public void SetSpawnRate(float newSpawnTime)
    {
        if (newSpawnTime > 0)
        {
            targetSpawnTime = newSpawnTime; 
        }
        else
        {
            Debug.LogWarning("Некорректное значение задержки спавна!");
        }
    }
    
    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void ResumeSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnOranges());
    }
    public float GetSpawnRate()
    {
        return targetSpawnTime;
    }
}