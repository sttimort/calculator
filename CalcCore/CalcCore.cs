using System;
using System.Collections.Generic;

namespace Calculator
{
	class CalcCore : ICalcCore
	{
		List<HistoryEntry> history;
		public HistoryEntry lastEntry => history[history.Count - 1];

		public CalcCore(double firstValue)
		{
			history = new List<HistoryEntry>();
			history.Add(new HistoryEntry(1, firstValue));
		}

		public void add(double operand)
		{
			history.Add(new HistoryEntry(history.Count + 1, lastEntry.value + operand));
		}

		public void substract(double operand)
		{
			history.Add(new HistoryEntry(history.Count + 1, lastEntry.value - operand));
		}

		public void mult(double operand)
		{
			history.Add(new HistoryEntry(history.Count + 1, lastEntry.value* operand));
		}

		public void div(double operand)
		{
			if (operand == 0) throw new ZeroDivisionError();
			history.Add(new HistoryEntry(history.Count + 1, lastEntry.value / operand));
		}

		public void goToEntry(int entryId)
		{
			if (entryId > history.Count || entryId < 1)
				throw new EntryIdError();

			while (lastEntry.id != entryId)
				history.RemoveAt(history.Count - 1);
		}
	}
}
