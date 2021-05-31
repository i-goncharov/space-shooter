using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotaror : MonoBehaviour
{
    private float tumble = 5.0f;

	void Start ()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
