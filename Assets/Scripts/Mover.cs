using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	void FixedUpdate ()
    {
        GetComponent<Rigidbody>().velocity  = new Vector3(0, 10, 0);
    }
}
