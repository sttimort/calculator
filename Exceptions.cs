using System;

namespace Calculator
{
	abstract class CalcCoreError : Exception
	{
		protected CalcCoreError(string msg)
			: base(msg) { }
	}

	class ZeroDivisionError : CalcCoreError
	{
		public ZeroDivisionError(string msg = "")
			: base("Zero division error.\n" + msg) { }
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