using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class LoginControl : MonoBehaviour {

    public InputField playerAccount;        //账号
    public InputField playerPassword;       //密码

    //登陆
    public void login()
    {
        Debug.LogFormat("登陆事件：账号：{0}  密码：{1}", playerAccount.text, playerPassword.text);
        KBEngine.Event.fireIn("login", playerAccount.text, playerPassword.text, System.Text.Encoding.UTF8.GetBytes("PC"));  //发起登陆事件

        close();
        showAnimation();
    }

    //显示等待动画
    public void showAnimation()
    {
        Transform parent = GameObject.Find("Canvas/UI").transform;
        GameObject anim = (GameObject)Instantiate(Resources.Load("prefab/animation"));
        anim.transform.SetParent(parent, false);
    }


    //关闭界面
    public void close()
    {
        this.gameObject.SetActive(false);
    }
}
