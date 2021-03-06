using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Susi4.Plugin
{
	public static class Lib
	{
		[DllImport("SusiDevice")]
		public static extern UInt32 SusiDeviceGetValue(UInt32 Id, out UInt32 pValue);

		[DllImport("SusiDevice")]
		public static extern UInt32 SusiDeviceSetValue(UInt32 Id, UInt32 Value);

		public const UInt32 LTC4266_ID_BASE = 0x00200000;

		public const UInt32 LTC4266_ID_INFO_TYPE = 0x00000;
		public const UInt32 LTC4266_ID_INFO_BASE = LTC4266_ID_BASE | LTC4266_ID_INFO_TYPE;
		public const UInt32 LTC4266_ID_INFO_AVAILABLE = LTC4266_ID_INFO_BASE + 0;

		public const UInt32 LTC4266_ID_POWER_TYPE = 0x10000;
		public const UInt32 LTC4266_ID_POWER_BASE = LTC4266_ID_BASE | LTC4266_ID_POWER_TYPE;
		public const UInt32 LTC4266_ID_POWER_ENABLE = LTC4266_ID_POWER_BASE + 0;
		public const UInt32 LTC4266_ID_POWER_DISABLE = LTC4266_ID_POWER_BASE + 1;

		public const UInt32 LTC4266_ID_DETECT_TYPE = 0x20000;
		public const UInt32 LTC4266_ID_DETECT_BASE = LTC4266_ID_BASE | LTC4266_ID_DETECT_TYPE;
		public const UInt32 LTC4266_ID_DETECT_PORT1 = LTC4266_ID_DETECT_BASE + 0;
		public const UInt32 LTC4266_ID_DETECT_PORT2 = LTC4266_ID_DETECT_BASE + 1;
		public const UInt32 LTC4266_ID_DETECT_PORT3 = LTC4266_ID_DETECT_BASE + 2;
		public const UInt32 LTC4266_ID_DETECT_PORT4 = LTC4266_ID_DETECT_BASE + 3;

		public const UInt32 LTC4266_ID_CLASS_TYPE = 0x30000;
		public const UInt32 LTC4266_ID_CLASS_BASE = LTC4266_ID_BASE | LTC4266_ID_CLASS_TYPE;
		public const UInt32 LTC4266_ID_CLASS_PORT1 = LTC4266_ID_CLASS_BASE + 0;
		public const UInt32 LTC4266_ID_CLASS_PORT2 = LTC4266_ID_CLASS_BASE + 1;
		public const UInt32 LTC4266_ID_CLASS_PORT3 = LTC4266_ID_CLASS_BASE + 2;
		public const UInt32 LTC4266_ID_CLASS_PORT4 = LTC4266_ID_CLASS_BASE + 3;

		public const UInt32 LTC4266_ID_CURRENT_TYPE = 0x40000;
		public const UInt32 LTC4266_ID_CURRENT_BASE = LTC4266_ID_BASE | LTC4266_ID_CURRENT_TYPE;
		public const UInt32 LTC4266_ID_CURRENT_PORT1 = LTC4266_ID_CURRENT_BASE + 0;
		public const UInt32 LTC4266_ID_CURRENT_PORT2 = LTC4266_ID_CURRENT_BASE + 1;
		public const UInt32 LTC4266_ID_CURRENT_PORT3 = LTC4266_ID_CURRENT_BASE + 2;
		public const UInt32 LTC4266_ID_CURRENT_PORT4 = LTC4266_ID_CURRENT_BASE + 3;

		public const UInt32 LTC4266_ID_VOLTAGE_TYPE = 0x50000;
		public const UInt32 LTC4266_ID_VOLTAGE_BASE = LTC4266_ID_BASE | LTC4266_ID_VOLTAGE_TYPE;
		public const UInt32 LTC4266_ID_VOLTAGE_PORT1 = LTC4266_ID_VOLTAGE_BASE + 0;
		public const UInt32 LTC4266_ID_VOLTAGE_PORT2 = LTC4266_ID_VOLTAGE_BASE + 1;
		public const UInt32 LTC4266_ID_VOLTAGE_PORT3 = LTC4266_ID_VOLTAGE_BASE + 2;
		public const UInt32 LTC4266_ID_VOLTAGE_PORT4 = LTC4266_ID_VOLTAGE_BASE + 3;
	}
}
