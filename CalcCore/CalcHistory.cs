using System.Collections.Generic;
using Calculator.Interfaces;
using Calculator.Enumumerations;

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

		public void Clear()
		{
			_entryList.RemoveAll((CalcHistoryEntry obj) => true);
		}

		public void Add(OpType opType, double operand, double value)
		{
			_entryList.Add(new CalcHistoryEntry(_entryList.Count + 1, opType, operand, value));
		}

		public double Get(int entryID)
		{
			if (entryID > _entryList.Count || entryID< 1)
				throw new EntryIdError();

			return _entryList[entryID - 1].value;
		}

		public List<KeyValuePair<OpType, double>> GetKeyValueList()
		{
			List<KeyValuePair<OpType, double>> opList = new List<KeyValuePair<OpType, double>>();

			foreach (var entry in _entryList)
			{
				opList.Add(new KeyValuePair<OpType, double>(entry.opType, entry.operand));
			}

			return opList;
		}
	}
}
