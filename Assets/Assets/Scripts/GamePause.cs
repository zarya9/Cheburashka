using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pausePanel;
    public OrangeSpawner orangeSpawner;
    private float savedSpawnRate;
    public bool IsPause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPause = !IsPause;

            if (!IsPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        IsPause = true;
        if (orangeSpawner != null)
        {
            savedSpawnRate = orangeSpawner.GetSpawnRate();
            orangeSpawner.SetSpawnRate(0f);
        }
        Time.timeScale = 0f;
        //pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        IsPause = false;
        if (orangeSpawner != null)
        {
            orangeSpawner.SetSpawnRate(savedSpawnRate); 
        }
        Time.timeScale = 1f;
        //pausePanel.SetActive(false);
    }
}
