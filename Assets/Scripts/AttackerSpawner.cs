using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;

    [SerializeField] Attacker[] AttackerPrefab;
    [SerializeField] int minSpawnDelay = 1;
    public int maxSpawnDelay = 5;




    //int spawnAttackerIndex;



    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnSttacker();
        }
    }

    public void StopSpawing()
    {
        spawn = false;
    }

    private void Awake()
    {
        PlayerPrefsController.GetDifficulty();
        SetDifficulty();
    }

    private void SpawnSttacker()
    {
        Spawn(Random.Range(0, AttackerPrefab.Length));


    }

    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate(AttackerPrefab[index], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }


    private void SetDifficulty()
    {

        if (PlayerPrefsController.GetDifficulty() == 0)
        {
            maxSpawnDelay = 5;

        }
        else if (PlayerPrefsController.GetDifficulty() == 1)
        {
            maxSpawnDelay = 4;

        }
        else if (PlayerPrefsController.GetDifficulty() == 2)
        {
            maxSpawnDelay = 3;
        }

    }
}
