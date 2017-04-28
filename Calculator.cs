using System;
using System.Collections.Generic;
using Calculator.Interfaces;
using Calculator.Enumumerations;
using Calculator.CalcUI;
using Calculator.CalcCore;
using Calculator.CalcData;

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
					_cc.goToEntry(int.Parse(op.rawArg)); // no need for TryParse beacause of regex
					break;
				case OpType.SAVE:
					Data.Save(op.rawArg, _cc.HistoryKeyValueList);
					break;
				case OpType.LOAD:
					_performLoading(Data.Load(op.rawArg));
					break;

				default:
					throw new ProgammShoudNotReachThisCodeError("_executeCommand switch default clause");
			}
		}

		void _performLoading(List<KeyValuePair<OpType, double>> opList)
		{
			foreach (var pair in opList)
			{
				var opType = pair.Key;
				var operand = pair.Value;

				switch (opType)
				{
					case OpType.INIT:
						_cc.init(operand);
						break;
					case OpType.ADD:
						_cc.add(operand);
						break;
					case OpType.SUB:
						_cc.substract(operand);
						break;
					case OpType.MULT:
						_cc.mult(operand);
						break;
					case OpType.DIV:
						_cc.div(operand);
						break;
					case OpType.GOTO:
						_cc.goToEntry((int)operand); // no need for TryParse beacause of regex
						break;
					default:
						throw new ProgammShoudNotReachThisCodeError("_executeCommand switch default clause");
				}
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
				catch (Exception e)
				{
					if (e is CalcCoreError || e is CalcDataException)
						Console.WriteLine(e.Message);
					else
						throw;
				}

				UI.showEntry(_cc.lastEntry);
			}
		}
	}
}
