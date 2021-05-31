using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLevel1 : MonoBehaviour {

    public GameObject Load;

    void Update()
    {
        if (Input.GetButtonDown("Back1") || Input.GetButtonDown("Back2"))
        {
            Load.SetActive(true);
        }
	}
}
