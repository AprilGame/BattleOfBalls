using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using UnityEngine.UI;

public class GameEntity : MonoBehaviour {

    public bool isPlayer = false;
    public bool isAccount = false;
    public bool isIn = false;
    public GameObject textObj;
    private GameObject   go;

    private Vector3 _position = Vector3.zero;
    public Vector3 destPosition = Vector3.zero;

    private float _speed = 2f;
    // Use this for initialization
    void Start() {

    }

    public Vector3 position
    {
        get
        {
            return _position;
        }

        set
        {
            _position = value;

            if (gameObject != null)
                gameObject.transform.position = _position;
        }
    }

    public float speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    // Update is called once per frame
    void Update() {

        if(textObj!=null&&go!=null)
        {
            go.transform.position=textObj.transform.position= Camera.main.WorldToScreenPoint(transform.position);
        }
        /*
        if(isIn&&textObj!=null)
        {
             textObj.transform.localPosition = Camera.main.WorldToScreenPoint(transform.position);
        }
        else if(textObj!=null)
        {
            textObj.transform.position= transform.position;
        }*/
        if (isPlayer||!isAccount)
            return;
        /*if (destPosition == Vector3.zero)
            return;*/

        float deltaSpeed = (speed * Time.deltaTime);
 
            float dist = Vector3.Distance(new Vector3(destPosition.x, destPosition.y, 0f),
                    new Vector3(position.x, position.y, 0f));
            if (dist > 0.01f)
            {
                Vector3 pos = position;

                Vector3 movement = destPosition - pos;
                movement.z = 0f;
                movement.Normalize();

                movement *= deltaSpeed;

                if (dist > deltaSpeed || movement.magnitude > deltaSpeed)
                    pos += movement;
                else
                    pos = destPosition;

                position = pos;
            }
            else
            {
                position = destPosition;
            }
	}

    void FixedUpdate()
    {
        if (!isPlayer)
            return;

        KBEngine.Event.fireIn("updatePlayer",transform.position.x,
        transform.position.z, transform.position.y,transform.rotation.eulerAngles.y);
    }

    //设置玩家昵称
    public void setPlayerName(string name)
    {
        go= Instantiate(textObj, GameObject.Find("EasyTouchControlsCanvas").transform);
        go.GetComponent<Text>().text = name;
        //Text playerName = go.GetComponent<Text>();
       // playerName.text = name;
    }
}
