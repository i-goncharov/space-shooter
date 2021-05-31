using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {

    private float lifeT = 12.0f;//время жизни

    void Update()
    {
        lifeT -= Time.deltaTime;

        if (lifeT < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
