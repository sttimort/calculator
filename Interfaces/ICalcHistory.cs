using Calculator.Enumumerations;

namespace Calculator.Interfaces
{
	public interface ICalcHistory
	{
		CalcHistoryEntry Last { get; }
		void Add(OpType opType, double operand, double value);
		double Get(int entryID);
	}
}
