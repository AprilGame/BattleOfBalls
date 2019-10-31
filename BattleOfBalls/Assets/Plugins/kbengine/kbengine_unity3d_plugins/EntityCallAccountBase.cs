/*
	Generated by KBEngine!
	Please do not modify this file!
	
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Account.def
	public class EntityBaseEntityCall_AccountBase : EntityCall
	{

		public EntityBaseEntityCall_AccountBase(Int32 eid, string ename) : base(eid, ename)
		{
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_BASE;
		}

		public void playBattleGame()
		{
			Bundle pBundle = newCall("playBattleGame", 0);
			if(pBundle == null)
				return;

			sendCall(null);
		}

		public void playIndiviGame()
		{
			Bundle pBundle = newCall("playIndiviGame", 0);
			if(pBundle == null)
				return;

			sendCall(null);
		}

		public void playTeamGame()
		{
			Bundle pBundle = newCall("playTeamGame", 0);
			if(pBundle == null)
				return;

			sendCall(null);
		}

		public void playerLeaveRoom()
		{
			Bundle pBundle = newCall("playerLeaveRoom", 0);
			if(pBundle == null)
				return;

			sendCall(null);
		}

		public void updatePlayerExp(UInt16 arg1)
		{
			Bundle pBundle = newCall("updatePlayerExp", 0);
			if(pBundle == null)
				return;

			bundle.writeUint16(arg1);
			sendCall(null);
		}

		public void updatePlayerName(string arg1)
		{
			Bundle pBundle = newCall("updatePlayerName", 0);
			if(pBundle == null)
				return;

			bundle.writeUnicode(arg1);
			sendCall(null);
		}

	}

	public class EntityCellEntityCall_AccountBase : EntityCall
	{

		public EntityCellEntityCall_AccountBase(Int32 eid, string ename) : base(eid, ename)
		{
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_CELL;
		}

	}
	}