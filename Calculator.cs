using System;
using Calculator.Interfaces;
using Calculator.Enumumerations;
using Calculator.CalcUI;
using Calculator.CalcCore;

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
					_cc.add(UI.operandPrompt());
					break;
				case OpType.SUB:
					_cc.substract(UI.operandPrompt());
					break;
				case OpType.MULT:
					_cc.mult(UI.operandPrompt());
					break;
				case OpType.DIV:
					_cc.div(UI.operandPrompt());
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
			UI.printUsage();

			_cc = new Core(UI.operandPrompt());
			UI.showEntry(_cc.lastEntry);

			Op op;
			while ((op = UI.opPrompt()).type != OpType.QUIT)
			{
				try
				{
					_executeCommand(op);
				}
				catch(CalcCoreError e)
				{
					Console.WriteLine(e.Message);
				}
				
				UI.showEntry(_cc.lastEntry);
			}
		}
	}
}
