using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class RoomManager : MonoBehaviour
{


    public Camera mainCamera;
    public GameObject player;
    public GameObject otherPlayer;
    public GameObject food, smash;
    public float time = 480;
    public Text gameTime;
    public Text gameMass;
    private int playerNum;          //玩家数量
    private bool start = false;     //是否进行倒计时

    public List<GameObject> textList = new List<GameObject>();
    public static Dictionary<string, int> playerDict = new Dictionary<string, int>();
    public ETCJoystick ETC;
    public ETCBase ETCb;
    // ETC.setPlayerSPeed(2, 2);

    void Start()
    {

        installEvents();
        //ETC.cameraLookAt = player.transform;
        ETC.setPlayerSPeed(2, 2);
        //InvokeRepeating("updatePlayerRange", 1, 4.0f);
    }

    void Update()
    {
        if(time>0&&start)
        {
            time -= Time.deltaTime;
            int m = (int)time / 60;
            int s = (int)time % 60;
            gameTime.text = string.Format("{0:D}:{1:D2}",m,s);
            //gameTime.text = time.ToString("00");
        }
    }

    void installEvents()
    {
        KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
        KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
        KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
        KBEngine.Event.registerOut("set_position", this, "set_position");
        KBEngine.Event.registerOut("addSpaceGeometryMapping", this, "addSpaceGeometryMapping");

        KBEngine.Event.registerOut("updatePlayerMass", this, "updatePlayerMass");
        KBEngine.Event.registerOut("updatePlayerSpeed", this, "updatePlayerSpeed");
        KBEngine.Event.registerOut("updatePlayerScale", this, "updatePlayerScale");
        KBEngine.Event.registerOut("updatePlayerLayer", this, "updatePlayerLayer");
        KBEngine.Event.registerOut("onPlayerDead", this, "onPlayerDead");
        KBEngine.Event.registerOut("onPlayerAlive", this, "onPlayerAlive");
        KBEngine.Event.registerOut("playerGameOver", this, "playerGameOver");

    }
    public void onEnterWorld(KBEngine.Entity entity)
    {
        if(entity.isPlayer())
        {
            playerNum++;
            string path = "prefab/ball" + ((Account)entity).modelType;
            Debug.Log(path);
            GameObject prefab = Resources.Load<GameObject>(path);
            player= Instantiate(prefab, new Vector3(0, 0),
               Quaternion.Euler(new Vector3(entity.direction.y, entity.direction.z, entity.direction.x))) as UnityEngine.GameObject;

            entity.renderObj = player;
            ETC.cameraLookAt = player.transform;
            ETC.axisX._directTransform = player.transform;
            ETC.axisY._directTransform = player.transform;
            

            GameEntity gameEntity = player.GetComponent<GameEntity>();
            gameEntity.isPlayer = true;
            gameEntity.isAccount = true;
            gameEntity.setPlayerName(((Account)entity).playerName);

            updatePosition(entity);
            updatePlayerDict(((Account)entity).playerName,0);
        
        }
        else
        {
            if(entity.className=="Food")
            {
                string path = "prefab/food" + ((Food)entity).modelType;
                GameObject food = Resources.Load<GameObject>(path);
                entity.renderObj = Instantiate(food, new Vector3(entity.position.x, entity.position.z),
                Quaternion.Euler(new Vector3(entity.direction.y, entity.direction.z, entity.direction.x))) as UnityEngine.GameObject;
            }
            else if(entity.className=="Smash")
            {
                string path = "prefab/smash" + ((Smash)entity).modelType;
                GameObject smash = Resources.Load<GameObject>(path);
                entity.renderObj = Instantiate(smash, new Vector3(entity.position.x, entity.position.z),
                Quaternion.Euler(new Vector3(entity.direction.y, entity.direction.z, entity.direction.x))) as UnityEngine.GameObject;
            }
            else
            {
                playerNum++;
                string path = "prefab/ball" + ((Account)entity).modelType;
                GameObject prefab = Resources.Load<GameObject>(path);
                GameObject otherPlayer = Instantiate(prefab, new Vector3(0, 0),
                   Quaternion.Euler(new Vector3(entity.direction.y, entity.direction.z, entity.direction.x))) as UnityEngine.GameObject;

                entity.renderObj = otherPlayer;
                GameEntity gameEntity = otherPlayer.GetComponent<GameEntity>();
                gameEntity.isAccount = true;
                gameEntity.setPlayerName(((Account)entity).playerName);
                updatePlayerDict(((Account)entity).playerName, 0);
            }
        }

        if(playerNum==2)
        {
            closeWaitingTime();
            start = true;
        }
    }

    public void onLeaveWorld(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;

        UnityEngine.GameObject.Destroy((UnityEngine.GameObject)entity.renderObj);
        entity.renderObj = null;
    }

    public void updatePosition(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;

        GameEntity gameEntity = ((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>();
        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        gameEntity.destPosition = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
    }

    //更新玩家质量
    public void updatePlayerMass(KBEngine.Entity entity,object v)
    {
        if(entity.isPlayer())
        {
            gameMass.text = string.Format("体重:{0}千克", (int)v);
        }
        updatePlayerDict(((Account)entity).playerName, (int)v);
    }

    //更新玩家字典
    public void updatePlayerDict(string key,int value)
    {
        playerDict[key] = value;
    }

    //更新玩家速度
    public void updatePlayerSpeed(KBEngine.Entity entity, object v)
    {
        float s = (float)v;
        if(entity.isPlayer())
        {
            ETC.setPlayerSPeed(s,s);
        }
        else if(entity.renderObj!=null)
        {
            ((GameObject)entity.renderObj).GetComponent<GameEntity>().speed = s;
        }
    }

    //更新玩家大小
    public void updatePlayerScale(KBEngine.Entity entity, object v)
    {
        float s = (float)v;
        if(entity.isPlayer())
        {
            mainCamera.orthographicSize =4+s;
        }
        if(entity.renderObj!=null)
        {
            ((GameObject)entity.renderObj).transform.localScale = new Vector3(s, s, s);
        }
    }

    //更新玩家显示等级
    public void updatePlayerLayer(KBEngine.Entity entity, object v)
    {
        int l = (int)v;
        if(entity.renderObj!=null)
        {
            ((GameObject)entity.renderObj).transform.GetComponent<SpriteRenderer>().sortingOrder = l;
        }
    }

    public void set_position(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
        go.GetComponent<GameEntity>().destPosition = currpos;
        go.GetComponent<GameEntity>().position = currpos;
    }

    //玩家dead
    public void onPlayerDead(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;
        ((GameObject)entity.renderObj).SetActive(false);
        if(entity.isPlayer())
        {
            showWaitingTime();
        }
    }

    //玩家复活
    public void onPlayerAlive(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;
        if(entity.isPlayer())
        {
            closeWaitingTime();
        }
        ((GameObject)entity.renderObj).SetActive(true);
    }


    //展开等待界面
    public void showWaitingTime()
    {
        Transform UI = GameObject.Find("EasyTouchControlsCanvas").transform;
        GameObject prefab = Resources.Load<GameObject>("prefab/GameWait");
        GameObject waitPage = GameObject.Instantiate(prefab, UI) as GameObject;
        GameWait gameWait = waitPage.GetComponent<GameWait>();
        gameWait.alive = true;
        gameWait.msg = "等待复活时间....";
    }

    //关闭等待界面
    public void closeWaitingTime()
    {
        GameObject waitPage = GameObject.Find("EasyTouchControlsCanvas/GameWait");
        if (waitPage == null)
            return;
        Destroy(waitPage);
    }

    //游戏结束
    public void playerGameOver()
    {
        //显示结算面板：
        Debug.Log("游戏结束!");
        Transform UI = GameObject.Find("EasyTouchControlsCanvas").transform;
        GameObject prefab = Resources.Load<GameObject>("prefab/overPanel");
        GameObject overPage = GameObject.Instantiate(prefab, UI) as GameObject;
    }

    public void addSpaceGeometryMapping(string path)
    {
        Debug.Log("进入房间");
        if (path == "spaces/GameMap")
        {
            //
        }
    }

    void updatePlayerRange()
    {
        int i = 0;
        if(playerDict.Count>0)
        {
            List<KeyValuePair<string, int>> lst = new List<KeyValuePair<string, int>>(playerDict);
            lst.Sort(delegate (KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)
            {
                return s2.Value.CompareTo(s1.Value);
            });

            foreach (KeyValuePair<string, int> p in lst)
            {
                textList[i].GetComponent<Text>().text = p.Key;
                i++;
            }
        }
       
    }

}
