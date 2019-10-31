using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

namespace KBEngine
{
    public class Account:AccountBase
    {
        public override void __init__()
        {
            base.__init__();
            if (isPlayer())
            {
                Event.registerIn("updatePlayer", this, "updatePlayer");

                // 触发登陆成功事件
                Event.fireOut("onLoginSuccessfully", new object[] { KBEngineApp.app.entity_uuid, id, this });
            }
        }

        public virtual void updatePlayer(float x, float y, float z, float yaw)
        {
            position.x = x;
            position.y = y;
            position.z = z;

            direction.z = yaw;
        }

        //监听质量变化
        public override void onPlayerMassChanged(int oldValue)
        {
            Event.fireOut("updatePlayerMass", new object[] { this, this.playerMass });
        }

        //监听速度变化
        public override void onPlayerSpeedChanged(float oldValue)
        {
            Event.fireOut("updatePlayerSpeed", new object[] { this, this.playerSpeed });
        }

        //监听大小变化
        public override void onPlayerScaleChanged(float oldValue)
        {
            Event.fireOut("updatePlayerScale", new object[] { this, this.playerScale });
        }

        //监听显示等级变化
        public override void onPlayerLayerChanged(int oldValue)
        {
            Event.fireOut("updatePlayerLayer", new object[] { this, this.playerLayer });
        }

        //玩家dead
        public override void playerDead(byte[] arg1)
        {
            Event.fireOut("onPlayerDead", new object[] { this });
        }

        //玩家复活
        public override void playerAlive(byte[] arg1)
        {
            Event.fireOut("onPlayerAlive", new object[] { this });
        }

        //游戏结束
        public override void playerGameOver()
        {
            Event.fireOut("playerGameOver");
        }


    }
}
