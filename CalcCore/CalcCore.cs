using System;
using System.Collections.Generic;

namespace Calculator
{
	class CalcCore : ICalcCore
	{
		ICalcHistory _history;
		public CalcHistoryEntry lastEntry => _history.Last;

		public CalcCore(double firstValue)
		{
			_history = new CalcHistory();
			_history.Add(firstValue);
		}

		public void add(double operand)
		{
			_history.Add(lastEntry.value + operand);
		}

		public void substract(double operand)
		{
			_history.Add(lastEntry.value - operand);
		}

		public void mult(double operand)
		{
			_history.Add(lastEntry.value * operand);
		}

		public void div(double operand)
		{
			if (operand == 0) throw new ZeroDivisionError();
			_history.Add(lastEntry.value / operand);
		}

		public void goToEntry(int entryID)
		{
			_history.Add(_history.Get(entryID));
		}
	}
}
