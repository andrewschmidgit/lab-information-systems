using System;

namespace LIS.LIS02A2
{
	public class PatientRecord : AbstractLisRecord
	{

		[LisRecordField(2)]
		public int SequenceNumber { get; set; }

		[LisRecordField(3)]
		public string PracticeAssignedPatientID { get; set; }

		[LisRecordField(4)]
		public string LaboratoryAssignedPatientID { get; set; }

		[LisRecordField(5)]
		public string PatientID3 { get; set; }

		[LisRecordField(6)]
		public PatientName PatientName { get; set; }

		[LisRecordField(7)]
		public PatientName MothersMaidenName { get; set; }

		[LisDateTimeUsage(LisDateTimeUsage.Date)]
		[LisRecordField(8)]
		public DateTime? Birthdate { get; set; } = null;

		[LisRecordField(9)]
		public PatientSex? PatientSex { get; set; } = null;

		[LisRecordField(14)]
		public string AttendingPhysicianID { get; set; }

		public override string ToLISString()
		{
			return "P" + new string(LISDelimiters.FieldDelimiter, 1) + base.ToLISString();
		}

		public PatientRecord(string aLisString)
			: base(aLisString)
		{
		}

		public PatientRecord()
		{
		}
	}
}
