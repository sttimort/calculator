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

	class ProgammShoudNotReachThisCodeError : Exception
	{
		public ProgammShoudNotReachThisCodeError(string msg = "")
			: base("Programm has reached the point it shoudn't\n" + msg) { }
	}
}