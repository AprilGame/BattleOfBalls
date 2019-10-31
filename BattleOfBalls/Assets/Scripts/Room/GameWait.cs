using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWait : MonoBehaviour {

    public Text timeText;
    public Text msgText;
    public float time = 5;
    public bool alive = false;
    public string msg;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time>0&& alive)
        {
            msgText.text = msg;
            time -= Time.deltaTime;
            timeText.text = time.ToString("00.0");
        }
        else
        {
            Debug.Log("销毁自身!");
            Destroy(gameObject);
        }
    }
}
