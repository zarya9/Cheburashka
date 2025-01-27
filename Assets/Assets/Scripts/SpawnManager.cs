using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject orangePrefab;
    public string spawnTag = "Respawn";

    void Start()
    {
        SpawnOranges();
    }

    void SpawnOranges()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            GameObject newOrange = Instantiate(orangePrefab, spawnPoint.transform.position, Quaternion.identity);
            newOrange.tag = spawnTag;
            Debug.Log("Оранжевый объект создан на " + spawnPoint.name + " с тегом: " + newOrange.tag);
        }
    }
}