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



	// defined in */scripts/entity_defs/types.xml

	public struct UINT8
	{
		Byte value;

		UINT8(Byte value)
		{
			this.value = value;
		}

		public static implicit operator Byte(UINT8 value)
		{
			return value.value;
		}

		public static implicit operator UINT8(Byte value)
		{
			Byte tvalue = (Byte)value;
			return new UINT8(tvalue);
		}

		public static Byte MaxValue
		{
			get
			{
				return Byte.MaxValue;
			}
		}

		public static Byte MinValue
		{
			get
			{
				return Byte.MinValue;
			}
		}
	}

	public struct UINT16
	{
		UInt16 value;

		UINT16(UInt16 value)
		{
			this.value = value;
		}

		public static implicit operator UInt16(UINT16 value)
		{
			return value.value;
		}

		public static implicit operator UINT16(UInt16 value)
		{
			UInt16 tvalue = (UInt16)value;
			return new UINT16(tvalue);
		}

		public static UInt16 MaxValue
		{
			get
			{
				return UInt16.MaxValue;
			}
		}

		public static UInt16 MinValue
		{
			get
			{
				return UInt16.MinValue;
			}
		}
	}

	public struct UINT64
	{
		UInt64 value;

		UINT64(UInt64 value)
		{
			this.value = value;
		}

		public static implicit operator UInt64(UINT64 value)
		{
			return value.value;
		}

		public static implicit operator UINT64(UInt64 value)
		{
			UInt64 tvalue = (UInt64)value;
			return new UINT64(tvalue);
		}

		public static UInt64 MaxValue
		{
			get
			{
				return UInt64.MaxValue;
			}
		}

		public static UInt64 MinValue
		{
			get
			{
				return UInt64.MinValue;
			}
		}
	}

	public struct UINT32
	{
		UInt32 value;

		UINT32(UInt32 value)
		{
			this.value = value;
		}

		public static implicit operator UInt32(UINT32 value)
		{
			return value.value;
		}

		public static implicit operator UINT32(UInt32 value)
		{
			UInt32 tvalue = (UInt32)value;
			return new UINT32(tvalue);
		}

		public static UInt32 MaxValue
		{
			get
			{
				return UInt32.MaxValue;
			}
		}

		public static UInt32 MinValue
		{
			get
			{
				return UInt32.MinValue;
			}
		}
	}

	public struct INT8
	{
		SByte value;

		INT8(SByte value)
		{
			this.value = value;
		}

		public static implicit operator SByte(INT8 value)
		{
			return value.value;
		}

		public static implicit operator INT8(SByte value)
		{
			SByte tvalue = (SByte)value;
			return new INT8(tvalue);
		}

		public static SByte MaxValue
		{
			get
			{
				return SByte.MaxValue;
			}
		}

		public static SByte MinValue
		{
			get
			{
				return SByte.MinValue;
			}
		}
	}

	public struct INT16
	{
		Int16 value;

		INT16(Int16 value)
		{
			this.value = value;
		}

		public static implicit operator Int16(INT16 value)
		{
			return value.value;
		}

		public static implicit operator INT16(Int16 value)
		{
			Int16 tvalue = (Int16)value;
			return new INT16(tvalue);
		}

		public static Int16 MaxValue
		{
			get
			{
				return Int16.MaxValue;
			}
		}

		public static Int16 MinValue
		{
			get
			{
				return Int16.MinValue;
			}
		}
	}

	public struct INT32
	{
		Int32 value;

		INT32(Int32 value)
		{
			this.value = value;
		}

		public static implicit operator Int32(INT32 value)
		{
			return value.value;
		}

		public static implicit operator INT32(Int32 value)
		{
			Int32 tvalue = (Int32)value;
			return new INT32(tvalue);
		}

		public static Int32 MaxValue
		{
			get
			{
				return Int32.MaxValue;
			}
		}

		public static Int32 MinValue
		{
			get
			{
				return Int32.MinValue;
			}
		}
	}

	public struct INT64
	{
		Int64 value;

		INT64(Int64 value)
		{
			this.value = value;
		}

		public static implicit operator Int64(INT64 value)
		{
			return value.value;
		}

		public static implicit operator INT64(Int64 value)
		{
			Int64 tvalue = (Int64)value;
			return new INT64(tvalue);
		}

		public static Int64 MaxValue
		{
			get
			{
				return Int64.MaxValue;
			}
		}

		public static Int64 MinValue
		{
			get
			{
				return Int64.MinValue;
			}
		}
	}

	public struct STRING
	{
		string value;

		STRING(string value)
		{
			this.value = value;
		}

		public static implicit operator string(STRING value)
		{
			return value.value;
		}

		public static implicit operator STRING(string value)
		{
			string tvalue = (string)value;
			return new STRING(tvalue);
		}
	}

	public struct UNICODE
	{
		string value;

		UNICODE(string value)
		{
			this.value = value;
		}

		public static implicit operator string(UNICODE value)
		{
			return value.value;
		}

		public static implicit operator UNICODE(string value)
		{
			string tvalue = (string)value;
			return new UNICODE(tvalue);
		}
	}

	public struct FLOAT
	{
		float value;

		FLOAT(float value)
		{
			this.value = value;
		}

		public static implicit operator float(FLOAT value)
		{
			return value.value;
		}

		public static implicit operator FLOAT(float value)
		{
			float tvalue = (float)value;
			return new FLOAT(tvalue);
		}

		public static float MaxValue
		{
			get
			{
				return float.MaxValue;
			}
		}

		public static float MinValue
		{
			get
			{
				return float.MinValue;
			}
		}
	}

	public struct DOUBLE
	{
		double value;

		DOUBLE(double value)
		{
			this.value = value;
		}

		public static implicit operator double(DOUBLE value)
		{
			return value.value;
		}

		public static implicit operator DOUBLE(double value)
		{
			double tvalue = (double)value;
			return new DOUBLE(tvalue);
		}

		public static double MaxValue
		{
			get
			{
				return double.MaxValue;
			}
		}

		public static double MinValue
		{
			get
			{
				return double.MinValue;
			}
		}
	}

	public struct PYTHON
	{
		byte[] value;

		PYTHON(byte[] value)
		{
			this.value = value;
		}

		public static implicit operator byte[](PYTHON value)
		{
			return value.value;
		}

		public static implicit operator PYTHON(byte[] value)
		{
			byte[] tvalue = (byte[])value;
			return new PYTHON(tvalue);
		}

		public Byte this[int ID]
		{
			get { return value[ID]; }
			set { this.value[ID] = value; }
		}
	}

	public struct PY_DICT
	{
		byte[] value;

		PY_DICT(byte[] value)
		{
			this.value = value;
		}

		public static implicit operator byte[](PY_DICT value)
		{
			return value.value;
		}

		public static implicit operator PY_DICT(byte[] value)
		{
			byte[] tvalue = (byte[])value;
			return new PY_DICT(tvalue);
		}

		public Byte this[int ID]
		{
			get { return value[ID]; }
			set { this.value[ID] = value; }
		}
	}

	public struct PY_TUPLE
	{
		byte[] value;

		PY_TUPLE(byte[] value)
		{
			this.value = value;
		}

		public static implicit operator byte[](PY_TUPLE value)
		{
			return value.value;
		}

		public static implicit operator PY_TUPLE(byte[] value)
		{
			byte[] tvalue = (byte[])value;
			return new PY_TUPLE(tvalue);
		}

		public Byte this[int ID]
		{
			get { return value[ID]; }
			set { this.value[ID] = value; }
		}
	}

	public struct PY_LIST
	{
		byte[] value;

		PY_LIST(byte[] value)
		{
			this.value = value;
		}

		public static implicit operator byte[](PY_LIST value)
		{
			return value.value;
		}

		public static implicit operator PY_LIST(byte[] value)
		{
			byte[] tvalue = (byte[])value;
			return new PY_LIST(tvalue);
		}

		public Byte this[int ID]
		{
			get { return value[ID]; }
			set { this.value[ID] = value; }
		}
	}

	public struct ENTITYCALL
	{
		byte[] value;

		ENTITYCALL(byte[] value)
		{
			this.value = value;
		}

		public static implicit operator byte[](ENTITYCALL value)
		{
			return value.value;
		}

		public static implicit operator ENTITYCALL(byte[] value)
		{
			byte[] tvalue = (byte[])value;
			return new ENTITYCALL(tvalue);
		}

		public Byte this[int ID]
		{
			get { return value[ID]; }
			set { this.value[ID] = value; }
		}
	}

	public struct BLOB
	{
		byte[] value;

		BLOB(byte[] value)
		{
			this.value = value;
		}

		public static implicit operator byte[](BLOB value)
		{
			return value.value;
		}

		public static implicit operator BLOB(byte[] value)
		{
			byte[] tvalue = (byte[])value;
			return new BLOB(tvalue);
		}

		public Byte this[int ID]
		{
			get { return value[ID]; }
			set { this.value[ID] = value; }
		}
	}

	public struct VECTOR2
	{
		Vector2 value;

		VECTOR2(Vector2 value)
		{
			this.value = value;
		}

		public static implicit operator Vector2(VECTOR2 value)
		{
			return value.value;
		}

		public static implicit operator VECTOR2(Vector2 value)
		{
			Vector2 tvalue = (Vector2)value;
			return new VECTOR2(tvalue);
		}

		public float x
		{
			get { return value.x; }
			set { this.value.x = value; }
		}

		public float y
		{
			get { return value.y; }
			set { this.value.y = value; }
		}

	}

	public struct VECTOR3
	{
		Vector3 value;

		VECTOR3(Vector3 value)
		{
			this.value = value;
		}

		public static implicit operator Vector3(VECTOR3 value)
		{
			return value.value;
		}

		public static implicit operator VECTOR3(Vector3 value)
		{
			Vector3 tvalue = (Vector3)value;
			return new VECTOR3(tvalue);
		}

		public float x
		{
			get { return value.x; }
			set { this.value.x = value; }
		}

		public float y
		{
			get { return value.y; }
			set { this.value.y = value; }
		}

		public float z
		{
			get { return value.z; }
			set { this.value.z = value; }
		}

	}

	public struct VECTOR4
	{
		Vector4 value;

		VECTOR4(Vector4 value)
		{
			this.value = value;
		}

		public static implicit operator Vector4(VECTOR4 value)
		{
			return value.value;
		}

		public static implicit operator VECTOR4(Vector4 value)
		{
			Vector4 tvalue = (Vector4)value;
			return new VECTOR4(tvalue);
		}

		public float x
		{
			get { return value.x; }
			set { this.value.x = value; }
		}

		public float y
		{
			get { return value.y; }
			set { this.value.y = value; }
		}

		public float z
		{
			get { return value.z; }
			set { this.value.z = value; }
		}

		public float w
		{
			get { return value.w; }
			set { this.value.w = value; }
		}
	}

	public class ENTITYLIST : List<byte[]>
	{

	}


}