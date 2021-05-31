using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Игроки")]
    public GameObject Player1;//Игрок 1
    public GameObject Player2;//Игрок 2
    [Header("Жизни игроков")]
    public Text p1L;
    public Text p2L;
    private int P1Life = 5;// кол-во жизней игрока 1
    private bool P1ll = false;// взят ли щит? 1
    private int P2Life = 5;//кол-во жизней игрока 2
    private bool P2ll = false;// взят ли щит? 2
    public GameObject[] p1Hills;//массив спрайтов (жизней)
    public GameObject[] p2Hills;//массив спрайтов (жизней)
    [Header("Бонусы игроков")]
    public GameObject Shld_1;//иконка щита 1
    public GameObject Shld_2;//иконка щита 2
    public GameObject Hill_1;//иконка жизней 1
    public GameObject Hill_2;//иконка жизней 2
    private bool Hill_trig1 = false;//для появления иконки жизней 1
    private bool Hill_trig2 = false;//для появления иконки жизней 2
    private float h1 = 0.0f;//для счетчика исчезновения иконки жизней 1
    private float h2 = 0.0f;//для счетчика исчезновения иконки жизней 2
    [Header("Вспывающие окна")]
    public GameObject P1Win;//игрок 1 победил
    public GameObject P2Win;//игрок 2 победил
    public GameObject Draw;//ничья
    public GameObject Paus;//пауза
    private bool draw = false;//ничья
    public GameObject Counter;//счетчик перед раундом
    private float c = 4.0f;//переменная для счетчика
    public Text CountText;//текст чсетчика перед раундом
    public GameObject CntRound;//счетчик раунда
    public Text CountRound;//текст чсетчика раунда
    private float tim = 65.0f;//время раунда
    [Header("Щит, жизни")]
    public GameObject Shield1;//фон щита 1
    public GameObject Shield2;//фон щита 2
    public GameObject Hill_bg1;//фон жизней 1
    public GameObject Hill_bg2;//фон жизней 2
    [Header("Другое")]
    public string seneMenu;//сцена с главным меню
    public static bool IsPaused = false;
    public GameObject LoaderMenu;//загрузчик меню

    void Update()
    {
        Application.targetFrameRate = 75;//ограничение fps
        QualitySettings.vSyncCount = 0;//отключение верикальной синхронизации
        p1L.text = string.Format("{0}", (int)P1Life);//число жизней 1
        p2L.text = string.Format("{0}", (int)P2Life);//число жизней 2
        
//--------------------------------------------------------------------вывод победа, ничья
        if (P1Life <= 0 && Player2.activeSelf == true)
        {
            P2W();
        }
        if (P2Life <= 0 && Player1.activeSelf == true)
        {
            P1W();
        }
        if (draw == true)//ничья
        {
            Player1.SetActive(false);
            Player2.SetActive(false);
            Draw.SetActive(true);
        }
//--------------------------------------------------------------------вызов паузы
        if (Input.GetButtonDown("Menu1") || Input.GetButtonDown("Menu2"))
        {
            if(IsPaused)
            {
                Resume();     
            }
            else
            {
                Pause();
            }
        }
        //счетчик перед раундом
        Count();
        //счетчик длительности раунда
        CounterRound();
        //--------------------------------------------------------------------появление иконки жизней
        if (Hill_trig1 == true)
        {
            Hill_1.SetActive(true);
            Hill_bg1.SetActive(true);
            h1 -= Time.deltaTime;
            if (h1 < 1)
            {
                Hill_1.SetActive(false);
                Hill_trig1 = false;
                Hill_bg1.SetActive(false);
            }
        }
        if (Hill_trig2 == true)
        {
            Hill_2.SetActive(true);
            Hill_bg2.SetActive(true);
            h2 -= Time.deltaTime;
            if (h2 < 1)
            {
                Hill_2.SetActive(false);
                Hill_trig2 = false;
                Hill_bg2.SetActive(false);
            }
        }
    }
    //--------------------------------------------------------------------вычитание жизней
    public void HP1 ()//вычитание жизней 1
    {
        P1Life -= 1;

        for (int i = 0; i < p1Hills.Length; i++)//вычитание иконок жизней
        {
            if (P1Life > i)
            {
                p1Hills[i].SetActive(true);
            }
            else
            {
                p1Hills[i].SetActive(false); 
            }
        }
    }
    public void HP2()//вычитание жизней 2
    {
        P2Life -= 1;

        for (int i = 0; i < p2Hills.Length; i++)//вычитание иконок жизней
        {
            if (P2Life > i)
            {
                p2Hills[i].SetActive(true);
            }
            else
            {
                p2Hills[i].SetActive(false);
            }
        }
    }
//--------------------------------------------------------------------вывод ничья\победы
    public void Draw_()//ничья
    {
        draw = true;
        Player1.SetActive(false);
        Player2.SetActive(false);
        CntRound.SetActive(false);
    }
    public void P1W()//Игрок1 победил 
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        P1Win.SetActive(true);
        CntRound.SetActive(false);
    }
    public void P2W()//Игрок2 победил 
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        P2Win.SetActive(true);
        CntRound.SetActive(false);
    }
//--------------------------------------------------------------------кнопки паузы
    public void Restart()//перезапуск уровня
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        CntRound.SetActive(true);
    }
    public void Pause()//пауза
    {
        Paus.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void Resume()//возобновить
    {
        Paus.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    public void MainMenu()//вызов главного меню
    {
        Time.timeScale = 1f;
        LoaderMenu.SetActive(true);
    }
    public void ExitGame()//выход из приложения
    {
        Application.Quit();//закрыть приложение
    }
    //--------------------------------------------------------------------отсчет перед матчем
    public void Count()//Счетчик - старт игры
    {
        if (c > 0)
        {
            c -= Time.deltaTime;
        }
        CountText.text = string.Format("{0}", (int)c);
        if (c < 1)
        {
            CountText.text = "БОЙ"; 
        }
        if (c < 0)
        {
            Counter.SetActive(false);
        }
    }
    //--------------------------------------------------------------------прибавление жизней
    public void Hill1()//прибавление иконок жизней 1
    {
        if (P1Life <= 4)
        {
            P1Life += 1;
            h1 += 3.0f;
            Hill_trig1 = true;
            Hill_bg1.SetActive(true);
        }
        for (int i = 0; i < p1Hills.Length; i++)
        {
            if (P1Life > i)
            {
                p1Hills[i].SetActive(true);         
            }
            else
            {
                p1Hills[i].SetActive(false);  
            }
        }
        if(P1Life < 6)
        {
            Shield1.SetActive(false);
            P1ll = false;
            Shld_1.SetActive(false);
        }
    }
    public void Hill2()//прибавление иконок жизней 2
    {
        if (P2Life <= 4)
        {
            P2Life += 1;
            h2 += 3.0f;
            Hill_trig2 = true;
            Hill_bg2.SetActive(true);
        }
        for (int i = 0; i < p2Hills.Length; i++)
        {
            if (P2Life > i)
            {
                p2Hills[i].SetActive(true);
            }
            else
            {
                p2Hills[i].SetActive(false);
            }
        }
        if (P2Life < 6)
        {
            Shield2.SetActive(false);
            P2ll = false;
            Shld_2.SetActive(false);
        }
    }
    //--------------------------------------------------------------------Щит
    public void Shield_1()//применение щита 1
    {
        if (P1Life < 6 && P1ll == false)
        {
            P1Life += 1;
            Shield1.SetActive(true);
            P1ll = true;
            Shld_1.SetActive(true);
        }
    }
    public void Shield_2()//применение щита 2
    {
        if (P2Life < 6 && P2ll == false)
        {
            P2Life += 1;
            Shield2.SetActive(true);
            P2ll = true;
            Shld_2.SetActive(true);
        }
    }
    public void ShieldFalse1()//отмена бонуса щит 1
    {
        P1ll = false;
        Shield1.SetActive(false);
        Shld_1.SetActive(false);
    }
    public void ShieldFalse2()//отмена бонуса щит 2
    {
        P2ll = false;
        Shield2.SetActive(false);
        Shld_2.SetActive(false);
    }
    //--------------------------------------------------------------------счетчик раунда
    public void CounterRound()
    {
        if (tim < 61)
        {
            CountRound.text = string.Format("{0}", (int)tim);
            CountRound.color = new Color(255, 255, 255);
        }
        if (tim > 0)
        {
            tim -= Time.deltaTime;
             
        }
        if (tim < 16)
        {
            CountRound.color = new Color(241/255.0f, 37/255.0f, 51/255.0f);
            CountRound.fontSize = 70;
        }
        if (tim < 0)
        {
            if (P1Life > P2Life)
            {
                P1W();
            }
            if (P1Life < P2Life)
            {
                P2W();
            }
            if (P1Life == P2Life)
            {
                Draw_();
            }
        }
    }
}