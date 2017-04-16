using System;
using System.Text.RegularExpressions;

namespace Calculator
{
	struct Op
	{
		public OpType type;
		public int? entryID; // not null only when GOTO (#<EntryID>) command were entered

		public Op(OpType type, int? entryID = null)
		{
			this.type = type;
			this.entryID = entryID;
		}
	}

	static class CalcParser
	{
		public static bool TryParse(string s, out Op? result)
		{
			Match m = Regex.Match(s, @"^(?:(\+)|(-)|(\*)|(/)|(#[1-9][0-9]*)|(q))$");
			if (!m.Success)
			{
				result = null;
				return false;
			}

			int successGroupIndex = 0;
			while (!m.Groups[++successGroupIndex].Success)
				{}

			int? entryID = null;
			if ((OpType)successGroupIndex == OpType.GOTO)
				entryID = int.Parse(s.Substring(1)); // regex matched, so no need for int.TryParse()
			
			result = new Op((OpType)successGroupIndex, entryID);
			return true;
		}		
	}
}
