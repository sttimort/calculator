using Calculator.Interfaces;

namespace Calculator.CalcCore
{
	class Core : ICalcCore
	{
		ICalcHistory _history;
		public CalcHistoryEntry lastEntry => _history.Last;

		public Core(double firstValue)
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
