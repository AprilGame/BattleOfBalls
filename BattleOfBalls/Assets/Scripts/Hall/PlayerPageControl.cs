using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPageControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //关闭界面
    public void closePage()
    {
        Debug.Log("dlf");
        Destroy(gameObject);
    }
}
