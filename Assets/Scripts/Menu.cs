using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool K_MSwitch = true;
	private Vector3 OldPosMous;
    [Header ("Главное меню")]
	public GameObject mMenu_KJ;
    public GameObject mMenu_M;

    void Start ()
	{
		OldPosMous = Input.mousePosition;//позиция курсора	
	}

    void Update()
    {
        Application.targetFrameRate = 60;//ограничение fps
        QualitySettings.vSyncCount = 0;//отключение верикальной синхронизации
        //проверка состояния
		if(K_MSwitch)
		{mMenu_KJ.SetActive(true);mMenu_M.SetActive(false);}
		if(!K_MSwitch)
		{mMenu_KJ.SetActive(false);mMenu_M.SetActive(true);}

        //клавиатура и геймпад
		float moveV1 = Input.GetAxis("Vertical1");
		float moveV2 = Input.GetAxis("Vertical2");
		if(Input.GetButtonDown("Vertical1")||Input.GetButtonDown("Vertical2")||moveV1>0.0f||moveV2>0.0f)
		{
			K_MSwitch = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		//мышь	
		if(Input.GetMouseButton(0)||Input.GetMouseButton(1)||Input.GetMouseButton(2)||OldPosMous != Input.mousePosition)
		{
			K_MSwitch = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			OldPosMous = Input.mousePosition;
		}
    }

    public void ExitGame()//выход из приложения
    {
        Application.Quit();
    }
}
