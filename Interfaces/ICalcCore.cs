using System;
namespace Calculator
{
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
