using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KBEngine;

public class HallPanelControl : MonoBehaviour {

    Account playerEntity;
    public Text playerNameText;
    public GameObject leftPage;
    public InputField playerNameInput;


	
	void Start () {

        playerEntity = KBEngineApp.app.player() as Account;
        Debug.Log(playerEntity.playerNameBase);
        Debug.Log("玩家姓名");
        playerNameText.text = playerEntity.playerNameBase.ToString();
    }
	
	
	void Update () {
		
	}


    /*************************************************大厅界面功能函数***********************************************/
    //点击头像：展示个人信息
    public void showInformation()
    {
        Transform UI = GameObject.Find("Canvas/UI").transform;
        GameObject prefab= Resources.Load<GameObject>("prefab/playerPage");
        GameObject playerPage = GameObject.Instantiate(prefab, UI) as GameObject;
    }

    //点击好友：展示好友界面
    public void showFriendsPage()
    {
        Transform UI = GameObject.Find("Canvas/UI").transform;
        GameObject prefab = Resources.Load<GameObject>("prefab/friendPage");
        GameObject friendPage = GameObject.Instantiate(prefab, UI) as GameObject;
    }

    //点击邮件：展示邮件界面
    public void showMailPage()
    {
        Transform UI = GameObject.Find("Canvas/UI").transform;
        GameObject prefab = Resources.Load<GameObject>("prefab/mailPage");
        GameObject mailPage = GameObject.Instantiate(prefab, UI) as GameObject;
    }


    //点击设置：展开设置界面
    public void showSettingPage()
    {
        Transform UI = GameObject.Find("Canvas/UI").transform;
        GameObject prefab = Resources.Load<GameObject>("prefab/settingPage");
        GameObject settingPage = GameObject.Instantiate(prefab, UI) as GameObject;
    }

    //点击右箭头：展开好友列表
    public void showFriendList()
    {
        leftPage.GetComponent<RectTransform>().offsetMin = new Vector2(437, -4);
    }

    //点击左箭头：关闭好友列表
    public void closeFriendList()
    {
        leftPage.GetComponent<RectTransform>().offsetMin = new Vector2(-437, -4);
    }

    //游戏模式：个人竞技
    public void playIndiviGame()
    {
        playerEntity.baseEntityCall.playIndiviGame();
        SceneManager.LoadScene(2);
    }

    //游戏模式：大逃杀
    public void playBattleGame()
    {
        playerEntity.baseEntityCall.playBattleGame();
    }

    //游戏模式：团队模式
    public void playTeamGame()
    {
        playerEntity.baseEntityCall.playTeamGame();
    }

    /************************************************修改用户名*************************************************/
    
    //点击用户名：切换输入框进行修改
    public void onClickPlayerName()
    {
        playerNameInput.gameObject.SetActive(true);
    }

    //保存修改：切换显示文本，保存用户名
    public void onSavePlayerName()
    {
        playerNameText.text = playerNameInput.text;
        playerNameInput.gameObject.SetActive(false);

        //保存到服务器
        playerEntity.baseEntityCall.updatePlayerName(playerNameText.text);
    }

}
