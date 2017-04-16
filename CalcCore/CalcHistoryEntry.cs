using Calculator.Enumumerations;

namespace Calculator
{
	public struct CalcHistoryEntry
	{
		public int entryID;
		public OpType opType;
		public double operand;
		public double value;

		public CalcHistoryEntry(int entryID, OpType opType, double operand, double value)
		{
			this.entryID = entryID;
			this.opType = opType;
			this.operand = operand;
			this.value = value;
		}
	}
}
