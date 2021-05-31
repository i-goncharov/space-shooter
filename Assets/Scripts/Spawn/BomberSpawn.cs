using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberSpawn : MonoBehaviour
{
    public GameObject[] Bombers;//объекты спавна
    public Vector3 spawnValues;//размер и координаты спавна
    public int hazardCount;//количество
    public float spawnWait;//ожидание появления
    public float startWait;//ожидание перед началом
    public float waveWait;//ожидание волны

    void Start ()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()//создаются объекты в цикле в рандомных местах по x
    {
        yield return new WaitForSeconds(startWait);//астероиды
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = Bombers[Random.Range(0, Bombers.Length)];
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
