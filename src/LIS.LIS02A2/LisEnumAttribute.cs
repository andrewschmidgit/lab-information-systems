using System;
using System.Runtime.CompilerServices;

namespace LIS.LIS02A2
{
	[AttributeUsage(AttributeTargets.Field)]
	internal class LisEnumAttribute : Attribute
	{

		public string LisID { get; set; }

		public LisEnumAttribute(string aLisID)
		{
			LisID = aLisID;
		}
	}
}
