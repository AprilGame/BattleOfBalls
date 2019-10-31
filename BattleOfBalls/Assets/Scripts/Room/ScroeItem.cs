using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScroeItem : MonoBehaviour {

    public Text rankText;
    public Text nameText;
    public Text massText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void initScroeData(int rank,string name,int mass)
    {
        rankText.text = rank.ToString() ;
        nameText.text = name;
        massText.text = mass.ToString();
    }
}
