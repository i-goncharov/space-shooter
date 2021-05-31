using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindJoistik : MonoBehaviour
{
    public int XBoxCntr = 1;
    //public bool XBox;
    public GameObject On_;
    public GameObject Off_;

    public void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int i = 0; i < names.Length; i++)
        {
            //print(names[i].Length);
            //XBox
            if (names[i].Length == 33)//xbox
            {
                XBoxCntr = 1;
            }
            if (names[i].Length != 33 && XBoxCntr == 1)
            {
                XBoxCntr = 0;
            }
        }//end for
        if(XBoxCntr == 1)
        {
            //XBox = true;
            Off_.SetActive(false);
            On_.SetActive(true);
        }
        if (XBoxCntr == 0)
        {
            //XBox = false;
            On_.SetActive(false);
            Off_.SetActive(true);
        }
    }//end Update
}//end class

