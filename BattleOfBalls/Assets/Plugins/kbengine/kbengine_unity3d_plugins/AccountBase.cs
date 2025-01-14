/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Account : AccountBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Account.def
	// Please inherit and implement "class Account : AccountBase"
	public abstract class AccountBase : Entity
	{
		public EntityBaseEntityCall_AccountBase baseEntityCall = null;
		public EntityCellEntityCall_AccountBase cellEntityCall = null;

		public Int32 modelType = 0;
		public virtual void onModelTypeChanged(Int32 oldValue) {}
		public Int64 playerExp = 0;
		public virtual void onPlayerExpChanged(Int64 oldValue) {}
		public UInt16 playerID = 0;
		public virtual void onPlayerIDChanged(UInt16 oldValue) {}
		public Int32 playerLayer = 1;
		public virtual void onPlayerLayerChanged(Int32 oldValue) {}
		public Int32 playerMass = 1;
		public virtual void onPlayerMassChanged(Int32 oldValue) {}
		public string playerName = "";
		public virtual void onPlayerNameChanged(string oldValue) {}
		public string playerNameBase = "";
		public virtual void onPlayerNameBaseChanged(string oldValue) {}
		public float playerScale = 1.0f;
		public virtual void onPlayerScaleChanged(float oldValue) {}
		public float playerSpeed = 8.0f;
		public virtual void onPlayerSpeedChanged(float oldValue) {}
		public Int32 playerState = 1;
		public virtual void onPlayerStateChanged(Int32 oldValue) {}

		public abstract void playerAlive(byte[] arg1); 
		public abstract void playerDead(byte[] arg1); 
		public abstract void playerGameOver(); 

		public AccountBase()
		{
		}

		public override void onComponentsEnterworld()
		{
		}

		public override void onComponentsLeaveworld()
		{
		}

		public override void onGetBase()
		{
			baseEntityCall = new EntityBaseEntityCall_AccountBase(id, className);
		}

		public override void onGetCell()
		{
			cellEntityCall = new EntityCellEntityCall_AccountBase(id, className);
		}

		public override void onLoseCell()
		{
			cellEntityCall = null;
		}

		public override EntityCall getBaseEntityCall()
		{
			return baseEntityCall;
		}

		public override EntityCall getCellEntityCall()
		{
			return cellEntityCall;
		}

		public override void attachComponents()
		{
		}

		public override void detachComponents()
		{
		}

		public override void onRemoteMethodCall(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Account"];

			UInt16 methodUtype = 0;
			UInt16 componentPropertyUType = 0;

			if(sm.usePropertyDescrAlias)
			{
				componentPropertyUType = stream.readUint8();
			}
			else
			{
				componentPropertyUType = stream.readUint16();
			}

			if(sm.useMethodDescrAlias)
			{
				methodUtype = stream.readUint8();
			}
			else
			{
				methodUtype = stream.readUint16();
			}

			Method method = null;

			if(componentPropertyUType == 0)
			{
				method = sm.idmethods[methodUtype];
			}
			else
			{
				Property pComponentPropertyDescription = sm.idpropertys[componentPropertyUType];
				switch(pComponentPropertyDescription.properUtype)
				{
					default:
						break;
				}

				return;
			}

			switch(method.methodUtype)
			{
				case 12:
					byte[] playerAlive_arg1 = stream.readEntitycall();
					playerAlive(playerAlive_arg1);
					break;
				case 11:
					byte[] playerDead_arg1 = stream.readEntitycall();
					playerDead(playerDead_arg1);
					break;
				case 13:
					playerGameOver();
					break;
				default:
					break;
			};
		}

		public override void onUpdatePropertys(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Account"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			while(stream.length() > 0)
			{
				UInt16 _t_utype = 0;
				UInt16 _t_child_utype = 0;

				{
					if(sm.usePropertyDescrAlias)
					{
						_t_utype = stream.readUint8();
						_t_child_utype = stream.readUint8();
					}
					else
					{
						_t_utype = stream.readUint16();
						_t_child_utype = stream.readUint16();
					}
				}

				Property prop = null;

				if(_t_utype == 0)
				{
					prop = pdatas[_t_child_utype];
				}
				else
				{
					Property pComponentPropertyDescription = pdatas[_t_utype];
					switch(pComponentPropertyDescription.properUtype)
					{
						default:
							break;
					}

					return;
				}

				switch(prop.properUtype)
				{
					case 40001:
						Vector3 oldval_direction = direction;
						direction = stream.readVector3();

						if(prop.isBase())
						{
							if(inited)
								onDirectionChanged(oldval_direction);
						}
						else
						{
							if(inWorld)
								onDirectionChanged(oldval_direction);
						}

						break;
					case 2:
						Int32 oldval_modelType = modelType;
						modelType = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onModelTypeChanged(oldval_modelType);
						}
						else
						{
							if(inWorld)
								onModelTypeChanged(oldval_modelType);
						}

						break;
					case 6:
						Int64 oldval_playerExp = playerExp;
						playerExp = stream.readInt64();

						if(prop.isBase())
						{
							if(inited)
								onPlayerExpChanged(oldval_playerExp);
						}
						else
						{
							if(inWorld)
								onPlayerExpChanged(oldval_playerExp);
						}

						break;
					case 5:
						UInt16 oldval_playerID = playerID;
						playerID = stream.readUint16();

						if(prop.isBase())
						{
							if(inited)
								onPlayerIDChanged(oldval_playerID);
						}
						else
						{
							if(inWorld)
								onPlayerIDChanged(oldval_playerID);
						}

						break;
					case 11:
						Int32 oldval_playerLayer = playerLayer;
						playerLayer = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onPlayerLayerChanged(oldval_playerLayer);
						}
						else
						{
							if(inWorld)
								onPlayerLayerChanged(oldval_playerLayer);
						}

						break;
					case 9:
						Int32 oldval_playerMass = playerMass;
						playerMass = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onPlayerMassChanged(oldval_playerMass);
						}
						else
						{
							if(inWorld)
								onPlayerMassChanged(oldval_playerMass);
						}

						break;
					case 4:
						string oldval_playerName = playerName;
						playerName = stream.readUnicode();

						if(prop.isBase())
						{
							if(inited)
								onPlayerNameChanged(oldval_playerName);
						}
						else
						{
							if(inWorld)
								onPlayerNameChanged(oldval_playerName);
						}

						break;
					case 3:
						string oldval_playerNameBase = playerNameBase;
						playerNameBase = stream.readUnicode();

						if(prop.isBase())
						{
							if(inited)
								onPlayerNameBaseChanged(oldval_playerNameBase);
						}
						else
						{
							if(inWorld)
								onPlayerNameBaseChanged(oldval_playerNameBase);
						}

						break;
					case 8:
						float oldval_playerScale = playerScale;
						playerScale = stream.readFloat();

						if(prop.isBase())
						{
							if(inited)
								onPlayerScaleChanged(oldval_playerScale);
						}
						else
						{
							if(inWorld)
								onPlayerScaleChanged(oldval_playerScale);
						}

						break;
					case 10:
						float oldval_playerSpeed = playerSpeed;
						playerSpeed = stream.readFloat();

						if(prop.isBase())
						{
							if(inited)
								onPlayerSpeedChanged(oldval_playerSpeed);
						}
						else
						{
							if(inWorld)
								onPlayerSpeedChanged(oldval_playerSpeed);
						}

						break;
					case 7:
						Int32 oldval_playerState = playerState;
						playerState = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onPlayerStateChanged(oldval_playerState);
						}
						else
						{
							if(inWorld)
								onPlayerStateChanged(oldval_playerState);
						}

						break;
					case 40000:
						Vector3 oldval_position = position;
						position = stream.readVector3();

						if(prop.isBase())
						{
							if(inited)
								onPositionChanged(oldval_position);
						}
						else
						{
							if(inWorld)
								onPositionChanged(oldval_position);
						}

						break;
					case 40002:
						stream.readUint32();
						break;
					default:
						break;
				};
			}
		}

		public override void callPropertysSetMethods()
		{
			ScriptModule sm = EntityDef.moduledefs["Account"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			Vector3 oldval_direction = direction;
			Property prop_direction = pdatas[2];
			if(prop_direction.isBase())
			{
				if(inited && !inWorld)
					onDirectionChanged(oldval_direction);
			}
			else
			{
				if(inWorld)
				{
					if(prop_direction.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onDirectionChanged(oldval_direction);
					}
				}
			}

			Int32 oldval_modelType = modelType;
			Property prop_modelType = pdatas[4];
			if(prop_modelType.isBase())
			{
				if(inited && !inWorld)
					onModelTypeChanged(oldval_modelType);
			}
			else
			{
				if(inWorld)
				{
					if(prop_modelType.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onModelTypeChanged(oldval_modelType);
					}
				}
			}

			Int64 oldval_playerExp = playerExp;
			Property prop_playerExp = pdatas[5];
			if(prop_playerExp.isBase())
			{
				if(inited && !inWorld)
					onPlayerExpChanged(oldval_playerExp);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerExp.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerExpChanged(oldval_playerExp);
					}
				}
			}

			UInt16 oldval_playerID = playerID;
			Property prop_playerID = pdatas[6];
			if(prop_playerID.isBase())
			{
				if(inited && !inWorld)
					onPlayerIDChanged(oldval_playerID);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerID.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerIDChanged(oldval_playerID);
					}
				}
			}

			Int32 oldval_playerLayer = playerLayer;
			Property prop_playerLayer = pdatas[7];
			if(prop_playerLayer.isBase())
			{
				if(inited && !inWorld)
					onPlayerLayerChanged(oldval_playerLayer);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerLayer.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerLayerChanged(oldval_playerLayer);
					}
				}
			}

			Int32 oldval_playerMass = playerMass;
			Property prop_playerMass = pdatas[8];
			if(prop_playerMass.isBase())
			{
				if(inited && !inWorld)
					onPlayerMassChanged(oldval_playerMass);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerMass.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerMassChanged(oldval_playerMass);
					}
				}
			}

			string oldval_playerName = playerName;
			Property prop_playerName = pdatas[9];
			if(prop_playerName.isBase())
			{
				if(inited && !inWorld)
					onPlayerNameChanged(oldval_playerName);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerName.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerNameChanged(oldval_playerName);
					}
				}
			}

			string oldval_playerNameBase = playerNameBase;
			Property prop_playerNameBase = pdatas[10];
			if(prop_playerNameBase.isBase())
			{
				if(inited && !inWorld)
					onPlayerNameBaseChanged(oldval_playerNameBase);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerNameBase.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerNameBaseChanged(oldval_playerNameBase);
					}
				}
			}

			float oldval_playerScale = playerScale;
			Property prop_playerScale = pdatas[11];
			if(prop_playerScale.isBase())
			{
				if(inited && !inWorld)
					onPlayerScaleChanged(oldval_playerScale);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerScale.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerScaleChanged(oldval_playerScale);
					}
				}
			}

			float oldval_playerSpeed = playerSpeed;
			Property prop_playerSpeed = pdatas[12];
			if(prop_playerSpeed.isBase())
			{
				if(inited && !inWorld)
					onPlayerSpeedChanged(oldval_playerSpeed);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerSpeed.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerSpeedChanged(oldval_playerSpeed);
					}
				}
			}

			Int32 oldval_playerState = playerState;
			Property prop_playerState = pdatas[13];
			if(prop_playerState.isBase())
			{
				if(inited && !inWorld)
					onPlayerStateChanged(oldval_playerState);
			}
			else
			{
				if(inWorld)
				{
					if(prop_playerState.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPlayerStateChanged(oldval_playerState);
					}
				}
			}

			Vector3 oldval_position = position;
			Property prop_position = pdatas[1];
			if(prop_position.isBase())
			{
				if(inited && !inWorld)
					onPositionChanged(oldval_position);
			}
			else
			{
				if(inWorld)
				{
					if(prop_position.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPositionChanged(oldval_position);
					}
				}
			}

		}
	}
}