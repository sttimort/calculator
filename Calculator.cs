using System;
using System.Text.RegularExpressions;

namespace task1
{
	enum OpType { ADD, SUB, MULT, DIV, GOTO, QUIT }

	struct Op
	{
		public OpType type;
		public int entryId;

		public Op(OpType type, int entryId)
		{
			this.type = type;
			this.entryId = entryId;
		}

		public static bool TryParse(string s, out Op? result)
		{
			Match m = Regex.Match(s, @"^(?:(\+)|(-)|(\*)|(/)|(#[1-9][0-9]*)|(q))$");
			if (!m.Success)
			{
				result = null;
				return false;
			}

			int successGroupIndex = 0;
			for (int i = 1; i <= 6; i++)
				if (m.Groups[i + 1].Success)
				{
					successGroupIndex = i;
					break;
				}

			result = new Op((OpType)successGroupIndex, successGroupIndex == 4 ? int.Parse(s.Substring(1)) : 0);
			return true;
		}
	}

	public class Calculator
	{
		CalcCore cc;

		public void start()
		{
			CalcUI.usage();

			cc = new CalcCore(CalcUI.operandPrompt());
			CalcUI.showEntry(cc.lastEntry);

			Op op;
			while ((op = CalcUI.opPrompt()).type != OpType.QUIT)
			{
				try
				{
					if (op.type == OpType.GOTO)
						cc.goToEntry(op.entryId);

					else if (op.type != OpType.QUIT)
						cc.performMathOp((CalcMathOp)op.type, CalcUI.operandPrompt());
				}
				catch(CalcCoreError e)
				{
					Console.WriteLine(e.Message);
				}
				
				CalcUI.showEntry(cc.lastEntry);
			} 
		}
	}
}
