using System;
namespace Calculator
{
	struct HistoryEntry
	{
		public int id;
		public double value;

		public HistoryEntry(int id, double value)
		{
			this.id = id;
			this.value = value;
		}
	}

	interface ICalcCore
	{
		HistoryEntry lastEntry { get; }
		void add(double operand);
		void substract(double operand);
		void mult(double operand);
		void div(double operand);
		void goToEntry(int id);
	}
}
