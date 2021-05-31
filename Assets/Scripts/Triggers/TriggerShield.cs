using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShield : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//столкновение Щит
        {
            FindObjectOfType<SoloGameManager>().Shield_1();
            Destroy(gameObject);
        }
        if (other.tag == "Player1")//столкновение Щит 1
        {
            FindObjectOfType<GameManager>().Shield_1();
            Destroy(gameObject);
        }
        if (other.tag == "Player2")//столкновение Щит 2
        {
            FindObjectOfType<GameManager>().Shield_2();
            Destroy(gameObject);
        }
        if (other.tag == "Asteroid")//столкновение c астероидом
        {
            Destroy(gameObject);
        }
        if (other.tag == "Hill")//столкновение cо щитом
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
