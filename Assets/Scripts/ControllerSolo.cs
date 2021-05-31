using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSolo : MonoBehaviour
{
    private float speed = 55.0f;//скорость
    private float tilt = 0.4f;//величина наклона
    private float fireRate = 0.18f;//задержка между выстрелами
    private float nextFire;//слеующий выстрел
    [Header("Выстрел")]
    public GameObject bullet;//присвоение объектра пуля
    public Transform bullPoint;//присвоение объектра точка появления пули
    [Header("Звук")]
    public AudioSource FireAudio;
    public AudioSource FlipAudio;
    private float flipping = 0.0f;//угол разворота игрока (180 или 0)
    private bool opened = false;//проверка нажата ли кнопка
	
	void Update ()
    {
        float moveHorisontal = Input.GetAxis("Horizontal1");//движение и вращение персонажа
        float moveVertical = Input.GetAxis("Vertical1");
        Vector3 movement = new Vector3(moveHorisontal, moveVertical, 0);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3//границы движения объекта
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, -75.0f, 75.0f),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, -42.3f, 42.3f),
            0.0f
            ); 
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)//выстрел
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bullPoint.position, bullPoint.rotation);
            FireAudio.Play();
        }
        if (Input.GetButtonDown("Flip1"))//отражение игрока по x
        {
            FlipAudio.Play();
            opened = !opened;
            if (opened == true)
            {
                flipping = 180f;
            }
            else
                flipping = 0.0f;
        }
        GetComponent<Rigidbody>().rotation = Quaternion.Euler//наклон при движении
            (
            GetComponent<Rigidbody>().velocity.y * tilt,
            flipping,//поворот в другую сторону(отражение)
            0.0f
            );
    }//Update End
}
