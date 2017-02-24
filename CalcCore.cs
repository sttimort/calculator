using System;
using System.Collections.Generic;

namespace Calculator
{
	struct Entry
	{
		public int id;
		public double value;

		public Entry(int id, double value)
		{
			this.id = id;
			this.value = value;
		}
	}

	enum CalcMathOp { ADD, SUB, MULT, DIV }

	class CalcCore
	{
		List<Entry> history;
		public Entry lastEntry => history[history.Count - 1];

		public CalcCore(double firstValue)
		{
			history = new List<Entry>();
			history.Add(new Entry(1, firstValue));
		}

		public void performMathOp(CalcMathOp op, double operand)
		{
			switch (op)
			{
				case CalcMathOp.ADD:
					history.Add(new Entry(history.Count + 1, lastEntry.value + operand));
					break;
				case CalcMathOp.SUB:
					history.Add(new Entry(history.Count + 1, lastEntry.value - operand));
					break;
				case CalcMathOp.MULT:
					history.Add(new Entry(history.Count + 1, lastEntry.value * operand));
					break;
				case CalcMathOp.DIV:
					if (Math.Abs(operand) == 0)
						throw new ZeroDivisionError();
					history.Add(new Entry(history.Count + 1, lastEntry.value / operand));
					break;
				default:
					throw new UnknownOperationError();
			}
		}

		public void goToEntry(int entryId)
		{
			if (entryId > history.Count || entryId < 1)
				throw new EntryIdError();

			while (lastEntry.id != entryId)
				history.RemoveAt(history.Count - 1);
		}
	}

	abstract class CalcCoreError : Exception
	{
		protected CalcCoreError(string msg)
			:base(msg) {}
	}

	class ZeroDivisionError : CalcCoreError
	{
		public ZeroDivisionError(string msg = "")
			:base("Zero division error.\n" + msg) { }
	}

	class EntryIdError : CalcCoreError
	{
		public EntryIdError(string msg = "")
			: base("Wrong entry id.\n" + msg) { }
	}

	class AbsentOperandError : CalcCoreError
	{
		public AbsentOperandError(string msg = "")
			: base("No operand found to perform operation.\n" + msg) { }
	}

	class UnknownOperationError : CalcCoreError
	{
		public UnknownOperationError(string msg = "")
			: base("Calculator's core got an unknown to it operation.\n" + msg) { }
	}
}
