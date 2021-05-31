using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoloGameManager : MonoBehaviour
{
    [Header("EventSysManager")]
    private bool PauseSwitch = true;
    private Vector3 OldPosMous;
    public GameObject PauseKJ;
    public GameObject PauseM;

    public GameObject Player1;//Игрок
    [Header("Жизни")]
    public Text p1L;
    private int P1Life = 5;// кол-во жизней игрока
    private bool P1ll = false;// взят ли щит?
    public GameObject[] p1Hills;//массив спрайтов (жизней)
    [Header("Бонусы иконки")]
    public GameObject Shld_1;//иконка щита
    public GameObject Hill_1;//иконка жизней
    private bool Hill_trig1 = false;//для появления иконки жизней
    private float h1 = 0.0f;//для счетчика исчезновения иконки жизней
    [Header("Щит/жизни аура")]
    public GameObject Shield1;//фон щита
    public GameObject Hill_bg1;//фон жизней
    [Header("Другое")]
    public string seneMenu;//сцена с главным меню
    public static bool IsPaused = false;
    public GameObject LoaderMenu;//загрузчик меню
    public GameObject Paus;//пауза

    void Start()
    {
        OldPosMous = Input.mousePosition;//позиция курсора	
    }

    void Update ()
    {
        //проверка состояния EventSys
        if (PauseSwitch)
        {PauseKJ.SetActive(true);PauseM.SetActive(false);}
        if (!PauseSwitch)
        {PauseKJ.SetActive(false);PauseM.SetActive(true);}
        //клавиатура и геймпад
        float moveV1 = Input.GetAxis("Vertical1");
        float moveV2 = Input.GetAxis("Vertical2");
        if (Input.GetButtonDown("Vertical1") || Input.GetButtonDown("Vertical2") || moveV1 > 0.0f || moveV2 > 0.0f)
        {
            PauseSwitch = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        //мышь	
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || OldPosMous != Input.mousePosition)
        {
            PauseSwitch = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            OldPosMous = Input.mousePosition;
        }

        Application.targetFrameRate = 75;//ограничение fps
        QualitySettings.vSyncCount = 0;//отключение верикальной синхронизации
        p1L.text = string.Format("{0}", (int)P1Life);//число жизней

        if (Input.GetButtonDown("Menu1") || Input.GetButtonDown("Menu2"))//вызов паузы
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }//--------------------------------------------------------------Update End

    public void Restart()//перезапуск уровня
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        //CntRound.SetActive(true);
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
    //------------------------------------------------------------прибавление иконок жизней
    public void Hill1()
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
        if (P1Life < 6)
        {
            Shield1.SetActive(false);
            P1ll = false;
            Shld_1.SetActive(false);
        }
    }
    //--------------------------------------------------------------------вычитание жизней
    public void HP1()//вычитание жизней
    {
        P1Life -= 1;

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
    }
    //-------------------------------------------------------------Щит
    public void Shield_1()//применение щита
    {
        if (P1Life < 6 && P1ll == false)
        {
            P1Life += 1;
            Shield1.SetActive(true);
            P1ll = true;
            Shld_1.SetActive(true);
        }
    }
    public void ShieldFalse1()//отмена бонуса щит
    {
        P1ll = false;
        Shield1.SetActive(false);
        Shld_1.SetActive(false);
    }
}
