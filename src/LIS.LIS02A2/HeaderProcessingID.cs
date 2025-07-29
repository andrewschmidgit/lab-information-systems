namespace LIS.LIS02A2
{
	public enum HeaderProcessingID
	{
		None,
		[LisEnum("P")]
		Production,
		[LisEnum("T")]
		Training,
		[LisEnum("D")]
		Debugging,
		[LisEnum("Q")]
		QualityControl
	}
}
