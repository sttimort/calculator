using System.Collections.Generic;
using Calculator.Enumumerations;

namespace Calculator.Interfaces
{
	public interface ICalcHistory
	{
		CalcHistoryEntry Last { get; }
		void Clear();
		void Add(OpType opType, double operand, double value);
		double Get(int entryID);
		List<KeyValuePair<OpType, double>> GetKeyValueList();
	}
}
