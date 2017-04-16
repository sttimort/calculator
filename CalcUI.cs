using System;

namespace Calculator.CalcUI
{
	public static class UI
	{
		public static void printUsage()
		{
			Console.WriteLine("Usage:\n" +
			                  "\twhen first symbol on line is '>' — enter operand (real number)\n" +
			                  "\twhen first symbol on line is '@' — enter operation\n" +
			                  "\t\toperation is one of '+', '-', '*', '/' or\n" +
			                  "\t\t\t'#' followed by ordinal of one of previous results\n" +
			                  "\t\t\t'q' to exit");
		}

		public static double operandPrompt()
		{
			string s;
			double result;
			bool isNum;

			do
			{
				Console.Write("> ");
				s = Console.ReadLine();
				if (!(isNum = double.TryParse(s, out result)))
					Console.WriteLine("Entered string is not a number, try again");
			} while (!isNum);

			return result;
		}

		public static Op opPrompt()
		{
			string s;
			Op? result;
			bool isOp;

			do
			{
				Console.Write("@: ");
				s = Console.ReadLine();
				if (!(isOp = CalcParser.TryParse(s, out result)))
					Console.WriteLine("Invalid command, try again");
			} while (!isOp);

			return result.Value;
		}

		public static void showEntry(CalcHistoryEntry entry)
		{
			Console.WriteLine("[#{0}] = {1}", entry.entryID, entry.value);
		}
	}
}
