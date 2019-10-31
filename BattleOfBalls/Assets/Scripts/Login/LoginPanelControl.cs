using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class LoginPanelControl : MonoBehaviour {

    public Text Msg;
    public GameObject loginPage, registPage;
	
	void Start () {
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
        KBEngine.Event.registerOut("onCreateAccountResult", this, "onCreateAccountResult");
    }
	
	
	void Update () {

	}


    //打开登陆界面
    public void showLoginPage()
    {
        loginPage.SetActive(true);
    }

    //打开注册界面
    public void showRegistPage()
    {
        registPage.SetActive(true);
    }

    //协程函数:关闭信息显示
    IEnumerator cleanMessage()
    {
        yield return new WaitForSeconds(1.0f);
        Msg.text = "";

    }


    //关闭动画
    public void closeAnimation()
    {
        Transform UI= GameObject.Find("Canvas/UI").transform;
        GameObject.Destroy(UI.GetChild(0).gameObject);
    }

    //注册结果
    public void onCreateAccountResult(UInt16 retcode, byte[] datas)
    {
        closeAnimation();

        if(retcode!=0)
        {
            Msg.text = "注册失败，请重新注册！";
            StartCoroutine(cleanMessage());
        }
        else
        {
            Msg.text = "注册成功，请登陆！";
            StartCoroutine(cleanMessage());
        }
    }
    
    //登陆失败，弹出信息窗口
    public void onLoginFailed(UInt16 failedcode)
    {
        closeAnimation();

        Debug.Log("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        Msg.text = "登陆失败，请重新登陆！";
        StartCoroutine(cleanMessage());
    }

    //登陆成功，进入大厅
    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, KBEngine.Account accountEntity)
    {
       
        if (KBEngineApp.app.player().id != accountEntity.id)
            return;

        closeAnimation();
        Transform parent = GameObject.Find("Canvas/UI").transform;
        GameObject slider = (GameObject)Instantiate(Resources.Load("prefab/progressbar"));
        slider.transform.SetParent(parent, false);
    }

}
