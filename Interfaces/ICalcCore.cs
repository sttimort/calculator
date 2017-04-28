using System.Collections.Generic;
using Calculator.Enumumerations;

namespace Calculator.Interfaces
{
	interface ICalcCore
	{
		CalcHistoryEntry lastEntry { get; }
		List<KeyValuePair<OpType, double>> HistoryKeyValueList { get; }
		void init(double operand);
		void add(double operand);
		void substract(double operand);
		void mult(double operand);
		void div(double operand);
		void goToEntry(int id);
	}
}
