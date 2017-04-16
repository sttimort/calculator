namespace Calculator
{
	public interface ICalcHistory
	{
		CalcHistoryEntry Last { get; }
		void Add(double value);
		double Get(int entryID);
	}
}
