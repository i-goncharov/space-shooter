using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHP : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//столкновение HP
        {
            Destroy(gameObject);
            FindObjectOfType<SoloGameManager>().Hill1();
        }
        if (other.tag == "Player1")//столкновение HP 1
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().Hill1();
        }
        if (other.tag == "Player2")//столкновение HP 2
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().Hill2();
        }
        if (other.tag == "Asteroid")//столкновение c астероидом
        {
            Destroy(gameObject);
        }
        if (other.tag == "Shield")//столкновение cо щитом
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "bullet")//столкновение c пулей
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
