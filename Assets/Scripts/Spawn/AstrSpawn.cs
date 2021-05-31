using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstrSpawn : MonoBehaviour
{
    public GameObject[] hazards;//присвоение объекта
    public Vector3 spawnValues;//
    public int hazardCount;//
    public float spawnWait;//ожидание появления
    public float startWait;//
    public float waveWait;//

    void Start()
    {
        StartCoroutine (SpawnWaves());
    }

    IEnumerator SpawnWaves()//создаются объекты в цикле в рандомных местах по x
    {
        yield return new WaitForSeconds(startWait);//астероиды
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
