using System.Collections.Generic;

namespace Calculator
{
	class CalcHistory : ICalcHistory
	{
		List<CalcHistoryEntry> _entryList;

		public CalcHistory()
		{
			_entryList = new List<CalcHistoryEntry>();
		}


		public CalcHistoryEntry Last => _entryList[_entryList.Count - 1];
		public void Add(double value)
		{
			_entryList.Add(new CalcHistoryEntry(_entryList.Count + 1, value));
		}

		public double Get(int entryID)
		{
			if (entryID > _entryList.Count || entryID< 1)
				throw new EntryIdError();

			return _entryList[entryID - 1].value;
		}
	}
}
