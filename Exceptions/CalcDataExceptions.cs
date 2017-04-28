using System;
namespace Calculator
{
	abstract class CalcDataException : Exception
	{
		protected CalcDataException(string msg)
			: base(msg) { }	
	}

	class DataLoadException : CalcDataException
	{
		public DataLoadException(string msg = "")
			: base(msg) { }
	}

	class CorruptedFileException : CalcDataException
	{
		public CorruptedFileException(string msg = "")
			: base("Can't load from file. File correpted.\n" + msg) { }	
	}

	class DataSaveException : CalcDataException
	{
		public DataSaveException(string msg = "")
			: base("Cang't save file." + msg) { }
	}
}
