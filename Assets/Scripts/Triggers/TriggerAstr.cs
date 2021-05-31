using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAstr : MonoBehaviour {

    private int hp = 2;

    public GameObject boom;
    private GameObject cloneBoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<SoloGameManager>().HP1();
            FindObjectOfType<SoloGameManager>().ShieldFalse1();
        }
        if (other.tag == "Player1")
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().HP1();
            FindObjectOfType<GameManager>().ShieldFalse1();
        }
        if (other.tag == "Player2")
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().HP2();
            FindObjectOfType<GameManager>().ShieldFalse2();
        }
        if (other.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            hp -= 1;
        }
        if (hp == 0)
        {
            cloneBoom = Instantiate(boom, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            Destroy(gameObject);
            Destroy(cloneBoom, 0.8f);
        }
        if (other.tag == "Shield" || other.tag == "Hill")
        {
            Destroy(other.gameObject);
        }
    }
}
