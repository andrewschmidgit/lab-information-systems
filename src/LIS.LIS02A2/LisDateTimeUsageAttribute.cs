using System;

namespace LIS.LIS02A2
{
	[AttributeUsage(AttributeTargets.Property)]
	internal class LisDateTimeUsageAttribute : Attribute
	{
		public LisDateTimeUsage DateTimeUsage { get; set; }

		public LisDateTimeUsageAttribute(LisDateTimeUsage dateTimeUsage)
		{
			DateTimeUsage = dateTimeUsage;
		}
	}
}
