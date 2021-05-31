using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public GameObject Sett;//окно настроек

    void Update ()
    {
        if (Input.GetButtonDown("Back1") || Input.GetButtonDown("Back2"))
        {
            Sett.SetActive(false);
        }
    }
}
