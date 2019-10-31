using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class registControl : MonoBehaviour {

    public Text ErrorMsg;
    public InputField playerPhone;
    public InputField playerPasword1;
    public InputField playerPaserod2;

    void Start()
    {
       
    }

    //创建账号
    public void createAccount()
    {

        if(playerPhone.text.Length!=11)
        {
            ErrorMsg.text = "手机号码格式错误！";
            Debug.Log("格式错误");
            return;
        }

        if(playerPasword1.text.Length<6)
        {
            ErrorMsg.text = "密码长度至少要六位";
            return;
        }

        if(playerPasword1.text != playerPaserod2.text)
        {
            ErrorMsg.text = "两次密码不匹配！";
            return;
        }

        KBEngine.Event.fireIn("createAccount", playerPhone.text, playerPasword1.text, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_balls"));
        close();
        showAnimation();
    }

    //显示等待动画
    public void showAnimation()
    {
        Transform parent = GameObject.Find("Canvas/UI").transform;
        GameObject anim = (GameObject)Instantiate(Resources.Load("prefab/registAnimation"));
        anim.transform.SetParent(parent, false);
    }

    //关闭注册界面
    public void close()
    {
        this.gameObject.SetActive(false);
    }



}
