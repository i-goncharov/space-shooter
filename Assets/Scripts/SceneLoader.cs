﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [Header ("Загружаемая сцена")]
    public int sceneID;
    [Header("Остальные объекты")]
    public Scrollbar loadImg;

	void Start ()
    {
        StartCoroutine(AsyncLoad());
	}
	
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;

            loadImg.size = progress;
            yield return null;
        }
    }

}
