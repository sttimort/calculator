using System;
namespace Calculator
{
	public struct CalcHistoryEntry
	{
		public int entryID;
		public double value;

		public CalcHistoryEntry(int entryID, double value)
		{
			this.entryID = entryID;

			this.value = value;
		}
	}
}
