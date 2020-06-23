using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject youLoseCanvas;
    public int attackersOnScene;
    bool levelTimerFinished = false;
    LevelLoader levelLoader;

   
    void Start()
    {
        winLabel.SetActive(false);
        youLoseCanvas.SetActive(false);

        levelLoader = GetComponent<LevelLoader>();
    }



    public void AttackerSpawned()
    {
        attackersOnScene++;
    }

    public void AttackerKilled()
    {
        attackersOnScene--;
        if (attackersOnScene <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
               
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawing();
        }
    }


    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5);
        levelLoader.LoadNextScene();

    }

    public void HandleLoseCondition()
    {
        youLoseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
