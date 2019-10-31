using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverGame : MonoBehaviour {

    public Transform Content;
	// Use this for initialization
	void Start () {

        Dictionary<string, int> dict = RoomManager.playerDict;
        List<KeyValuePair<string, int>> lst = new List<KeyValuePair<string, int>>(dict);
        lst.Sort(delegate (KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)
        {
            return s2.Value.CompareTo(s1.Value);
        });

        int i = 1;
        foreach (KeyValuePair<string, int> p in lst)
        {
            GameObject prefab =Resources.Load<GameObject>("prefab/scorItem");
            GameObject item = GameObject.Instantiate(prefab, Content) as GameObject;
            item.GetComponent<ScroeItem>().initScroeData(i, p.Key, p.Value);
            i++;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void close()
    {
        SceneManager.LoadScene(1);
    }


}
