using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KBEngine;

public class GameManager : MonoBehaviour
{
    /*
    public static Vector3 playerPos = Vector3.zero;
    public static float MAX_MAP_SIZE = 100;
    public static List<KBEngine.Entity> playerEntityList = new List<KBEngine.Entity>();

    void Start()
    {
        
        KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
        KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
        KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
        //KBEngine.Event.registerOut("set_position", this, "set_position");

    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void onEnterWorld(KBEngine.Entity entity)
    {


        if (entity.isPlayer())
         {
            //set_position(entity);
            playerEntityList.Add(entity);
             playerPos = new Vector3(entity.position.x, entity.position.z, 0);
         }
         else
         {

             if (entity.className == "Food")
             {
                 GameObject prefab = Resources.Load<GameObject>("prefab/food");
                 entity.renderObj = Instantiate(prefab, new Vector3(entity.position.x, entity.position.z, 1), Quaternion.identity);
             }
             else if (entity.className == "Smash")
             {
                 GameObject prefab = Resources.Load<GameObject>("prefab/smash");
                 entity.renderObj = Instantiate(prefab, new Vector3(entity.position.x, entity.position.z, 1), Quaternion.identity);
             }
             else
             {
                 Debug.Log("玩家进入世界，准备创建");
                 if (RoomManager.Instance == null)
                 {
                     playerEntityList.Add(entity);
                 }
                 else
                 {
                     GameObject prefab = Resources.Load<GameObject>("prefab/otherPlayer");
                     entity.renderObj = Instantiate(prefab, new Vector3(entity.position.x, entity.position.z, 1), Quaternion.identity);
                     GameEntity gameEntity = ((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>();
                    gameEntity.isAccount = true;
                 }
             }

         }
    }

    //实体离开世界
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

   /*public void set_position(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
        go.GetComponent<GameEntity>().destPosition = currpos;
        go.GetComponent<GameEntity>().position = currpos;
    }*/


}

