/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Food : FoodBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Food.def
	// Please inherit and implement "class Food : FoodBase"
	public abstract class FoodBase : Entity
	{
		public EntityBaseEntityCall_FoodBase baseEntityCall = null;
		public EntityCellEntityCall_FoodBase cellEntityCall = null;

		public UInt64 foodID = 0;
		public virtual void onFoodIDChanged(UInt64 oldValue) {}
		public Int32 modelType = 0;
		public virtual void onModelTypeChanged(Int32 oldValue) {}


		public FoodBase()
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
			baseEntityCall = new EntityBaseEntityCall_FoodBase(id, className);
		}

		public override void onGetCell()
		{
			cellEntityCall = new EntityCellEntityCall_FoodBase(id, className);
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
			ScriptModule sm = EntityDef.moduledefs["Food"];

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
				default:
					break;
			};
		}

		public override void onUpdatePropertys(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Food"];
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
					case 17:
						UInt64 oldval_foodID = foodID;
						foodID = stream.readUint64();

						if(prop.isBase())
						{
							if(inited)
								onFoodIDChanged(oldval_foodID);
						}
						else
						{
							if(inWorld)
								onFoodIDChanged(oldval_foodID);
						}

						break;
					case 16:
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
			ScriptModule sm = EntityDef.moduledefs["Food"];
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

			UInt64 oldval_foodID = foodID;
			Property prop_foodID = pdatas[4];
			if(prop_foodID.isBase())
			{
				if(inited && !inWorld)
					onFoodIDChanged(oldval_foodID);
			}
			else
			{
				if(inWorld)
				{
					if(prop_foodID.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onFoodIDChanged(oldval_foodID);
					}
				}
			}

			Int32 oldval_modelType = modelType;
			Property prop_modelType = pdatas[5];
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