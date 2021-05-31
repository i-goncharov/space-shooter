using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMultpr : MonoBehaviour
{
    private float speed = 55.0f;//скорость
    private float tilt = 0.4f;//величина наклона
    [Header("Номер игрока")]
    public int pNumber;//номер игрока

    private string NameAxisV;//имя направления движения
    private string NameAxisH;//имя направления движения
    private string Fire;//имя выстрела
    private string Flip;//имя отражения игрока по x

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
    private float count = 4.0f;//переменная для счетчика перед стартом игры

    void Start()
    {
        //Имя + номер игрока
        NameAxisH = "Horizontal" + pNumber;
        NameAxisV = "Vertical" + pNumber;
        Fire = "Fire" + pNumber;
        Flip = "Flip" + pNumber;
    }

    void Update()
    {
        count -= Time.deltaTime;//счетчик перед игрой
        //движение и вращение персонажа
        float moveHorisontal = Input.GetAxis(NameAxisH);
        float moveVertical = Input.GetAxis(NameAxisV);

        if (count < 0)
        {
            Vector3 movement = new Vector3(moveHorisontal, moveVertical, 0);
            GetComponent<Rigidbody>().velocity = movement * speed;
        }

        GetComponent<Rigidbody>().position = new Vector3//границы движения объекта
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, -75.0f, 75.0f),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, -42.3f, 42.3f),
            0.0f
            );

        //выстрел начало
        if (Input.GetButtonDown(Fire) && Time.time > nextFire && count < 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bullPoint.position, bullPoint.rotation);
            FireAudio.Play();
        }
        //выстрел конец

        if (Input.GetButtonDown(Flip) && count < 0)//отражение игрока по x
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

        GetComponent<Rigidbody>().rotation = Quaternion.Euler//наклон при движении объекта
            (
            GetComponent<Rigidbody>().velocity.y * tilt,
            flipping,//поворот в другую сторону(отражение)
            0.0f
            );
    }//Update end
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")//столкновение игроков
        {
            FindObjectOfType<GameManager>().Draw_();
        }
    }
}
