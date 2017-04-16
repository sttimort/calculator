using Calculator.Interfaces;
using Calculator.Enumumerations;

namespace Calculator.CalcCore
{
	class Core : ICalcCore
	{
		ICalcHistory _history;
		public CalcHistoryEntry lastEntry => _history.Last;

		public Core(double firstValue)
		{
			_history = new CalcHistory();
			_history.Add(OpType.ADD, firstValue, firstValue);
		}

		public void add(double operand)
		{
			_history.Add(OpType.ADD, operand, lastEntry.value + operand);
		}

		public void substract(double operand)
		{
			_history.Add(OpType.SUB, operand, lastEntry.value - operand);
		}

		public void mult(double operand)
		{
			_history.Add(OpType.MULT, operand, lastEntry.value * operand);
		}

		public void div(double operand)
		{
			if (operand == 0) throw new ZeroDivisionError();
			_history.Add(OpType.DIV, operand, lastEntry.value / operand);
		}

		public void goToEntry(int entryID)
		{
			_history.Add(OpType.GOTO, entryID, _history.Get(entryID));
		}
	}
}
