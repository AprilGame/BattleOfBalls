using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderControl : MonoBehaviour {

    public Slider slider;

	void Start () {

        //开启协程
        StartCoroutine(LoadAsync());
	}
	
    
    //协程函数
    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        
        while(operation.isDone==false)
        {
            float progress = operation.progress / 0.9f;
            slider.value = progress;

            yield return null;
        }
    }
}
