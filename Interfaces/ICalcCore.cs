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

	interface ICalcCore
	{

		CalcHistoryEntry lastEntry { get; }
		void add(double operand);
		void substract(double operand);
		void mult(double operand);
		void div(double operand);
		void goToEntry(int id);
	}
}
