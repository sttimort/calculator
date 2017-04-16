using System;

namespace Calculator
{
	public class Calculator
	{
		ICalcCore _cc;

		void _executeCommand(Op op)
		{
			switch (op.type)
			{
				case OpType.ADD:
					_cc.add(CalcUI.operandPrompt());
					break;
				case OpType.SUB:
					_cc.substract(CalcUI.operandPrompt());
					break;
				case OpType.MULT:
					_cc.mult(CalcUI.operandPrompt());
					break;
				case OpType.DIV:
					_cc.div(CalcUI.operandPrompt());
					break;
				case OpType.GOTO:
					if (!op.entryID.HasValue)
						throw new Exception("EntryID in GOTO command is null for some reason");
					_cc.goToEntry(op.entryID.Value);
					break;
				default:
					throw new ProgammShoudNotReachThisCodeError("_executeCommand switch default clause");
			}
		}
	
		public void start()
		{
			CalcUI.printUsage();

			_cc = new CalcCore(CalcUI.operandPrompt());
			CalcUI.showEntry(_cc.lastEntry);

			Op op;
			while ((op = CalcUI.opPrompt()).type != OpType.QUIT)
			{
				try
				{
					_executeCommand(op);
				}
				catch(CalcCoreError e)
				{
					Console.WriteLine(e.Message);
				}
				
				CalcUI.showEntry(_cc.lastEntry);
			}
		}
	}
}
