using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float Speed = 110.0f;
    private float lifeTime = 1.7f;

    public int pNumber;

    void Update ()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0.0f)
        {
            Destroy(gameObject);
        }

        if (pNumber == 1)
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.right * Speed;

        if (pNumber == 2)
            GetComponent<Rigidbody>().velocity = -GetComponent<Rigidbody>().transform.right * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player2" && pNumber==1)//столкновение пули с игроком2
        {
            FindObjectOfType<GameManager>().HP2();
            FindObjectOfType<GameManager>().ShieldFalse2();
            Destroy(gameObject);
        }
        if (other.tag == "Player1" && pNumber == 2)//столкновение пули с игроком1
        {
            FindObjectOfType<GameManager>().HP1();
            FindObjectOfType<GameManager>().ShieldFalse1();
            Destroy(gameObject);
        }
        if (other.tag == "bullet" || other.tag == "Shield" || other.tag == "Hill")//столкновение пули с другой пулей, жизнями, щитом
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "Asteroid")//столкновение пули с астероидом
        {
            Destroy(gameObject);
        }
    }
}
