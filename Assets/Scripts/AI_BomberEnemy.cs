using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BomberEnemy : MonoBehaviour
{
    private float speed = 20f;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//перемещение
        transform.LookAt(target, worldUp: Vector3.forward);//вращение
	}
}
