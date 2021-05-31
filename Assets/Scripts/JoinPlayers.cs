using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinPlayers : MonoBehaviour {

    public GameObject Wind;//окно подключения
    public GameObject ready1;//готовность первого
    public GameObject ready2;//готовность второго
    public GameObject Loader;//загрузчик уровня
    public GameObject Go;//кнопки "начать"
    private int active1 = 0;
    private int active2 = 0;
    private bool begin = false;//переключатель
	
	void Update ()
    {
        if (Input.GetButtonDown("Back1") || Input.GetButtonDown("Back2"))
        {
            Wind.SetActive(false);
            begin = false;
            ready2.SetActive(false);
            ready1.SetActive(false);
            active1 = 0;
            active2 = 0;
            Go.SetActive(false);
        }
        if (Input.GetButtonDown("Join1") && Wind == true)
        {
            ready1.SetActive(true);
            active1 += 1;
        }
        if (Input.GetButtonDown("Join2") && Wind == true)
        {
            ready2.SetActive(true);
            active2 += 1;
        }
        if (active1 > 0 && active2 > 0)
        {
            Go.SetActive(true);
            begin = true;
        }
        if (Input.GetButtonDown("Submit") && begin == true && Wind == true && active1 > 0 && active2 > 0 && Go == true)
        {
            Loader.SetActive(true);
        }
    }
}
