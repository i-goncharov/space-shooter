using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSysManager : MonoBehaviour 
{
	private bool PauseSwitch = true;
	private Vector3 OldPosMous;
	[Header ("Пауза")]
	public GameObject PauseKJ;
    public GameObject PauseM;
	[Header ("P1Win")]
	public GameObject P1W_KJ;
    public GameObject P1W_M;
	[Header ("P2Win")]
	public GameObject P2W_KJ;
    public GameObject P2W_M;
	[Header ("Drow")]
	public GameObject Drow_KJ;
    public GameObject Drow_M;

	void Start ()
	{
		OldPosMous = Input.mousePosition;//позиция курсора	
	}

	void Update () 
	{
		//проверка состояния
		if(PauseSwitch)
		{
			PauseKJ.SetActive(true);//пауза
			PauseM.SetActive(false);
			P1W_KJ.SetActive(true);//P1Win
			P1W_M.SetActive(false);
			P2W_KJ.SetActive(true);//P2Win
			P2W_M.SetActive(false);
			Drow_KJ.SetActive(true);//Drow
			Drow_M.SetActive(false);
		}
		if(!PauseSwitch)
		{
			PauseKJ.SetActive(false);//пауза
			PauseM.SetActive(true);
			P1W_KJ.SetActive(false);//P1Win
			P1W_M.SetActive(true);
			P2W_KJ.SetActive(false);//P2Win
			P2W_M.SetActive(true);
			Drow_KJ.SetActive(false);//Drow
			Drow_M.SetActive(true);
		}
		//Pause
		//клавиатура и геймпад
		float moveV1 = Input.GetAxis("Vertical1");
		float moveV2 = Input.GetAxis("Vertical2");
		if(Input.GetButtonDown("Vertical1")||Input.GetButtonDown("Vertical2")||moveV1>0.0f||moveV2>0.0f)
		{
			PauseSwitch = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		//мышь	
		if(Input.GetMouseButton(0)||Input.GetMouseButton(1)||Input.GetMouseButton(2)||OldPosMous != Input.mousePosition)
		{
			PauseSwitch = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			OldPosMous = Input.mousePosition;
		}
	}
}
