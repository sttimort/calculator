using System.Text.RegularExpressions;
using Calculator.Enumumerations;

namespace Calculator.CalcUI
{
	public struct Op
	{
		public OpType type;
		public string rawArg;

		public Op(OpType type, string argument = "")
		{
			this.type = type;
			this.rawArg = argument;
		}
	}

	static class CalcParser
	{
		public static bool TryParse(string s, out Op? result)
		{
			Match m = Regex.Match(s, @"^(?:(\+)|(-)|(\*)|(/)|(#[1-9][0-9]*)|(w:[\w]+)|(r:[\w]+)|(q))$");
			if (!m.Success)
			{
				result = null;
				return false;
			}

			int successGroupIndex = 0;
			while (!m.Groups[++successGroupIndex].Success)
				{}

			string rawArg = "";
			if ((OpType)successGroupIndex == OpType.GOTO)
				rawArg = s.Substring(1);

			if ((OpType)successGroupIndex == OpType.SAVE || (OpType)successGroupIndex == OpType.LOAD)
				rawArg = s.Substring(2);
			
			result = new Op((OpType)successGroupIndex, rawArg);
			return true;
		}		
	}
}
