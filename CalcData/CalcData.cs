using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Calculator.CalcUI;
using Calculator.Enumumerations;

namespace Calculator.CalcData
{
	public static class Data
	{
		public static List<KeyValuePair<OpType, double>> Load(string filename)
		{
			StreamReader sr;
			try
			{
				sr = new StreamReader(filename);
			}
			catch (System.Exception e)
			{
				throw new DataLoadException("Couldn't read file.\n" + e.Message);
			}

			List<KeyValuePair<OpType, double>> opList = new List<KeyValuePair<OpType, double>>();

			string line = sr.ReadLine();
			double initialValue;
			if (!double.TryParse(line, out initialValue)) // first line shoud be a number
				throw new CorruptedFileException();

			opList.Add(new KeyValuePair<OpType, double>(OpType.INIT, initialValue));

			while ((line = sr.ReadLine()) != null)
			{
				Match m = Regex.Match(line, @"(?:^% (?<op>\+|-|\*|/) (?<opd>-?\d+(?:\.\d+)?)$)|(?:Out\[(?<entryID>[1-9])+\])");
				if (!m.Success) // first line shoud be a number
					throw new CorruptedFileException();


				if (m.Groups["entryID"].Success)
					opList.Add(new KeyValuePair<OpType, double>(OpType.GOTO, double.Parse(m.Groups["entryID"].Value)));

				else if (m.Groups["op"].Success)
				{
					switch (m.Groups["op"].Value)
					{
						case "+":
							opList.Add(new KeyValuePair<OpType, double>(OpType.ADD, double.Parse(m.Groups["opd"].Value)));
							break;
						case "-":
							opList.Add(new KeyValuePair<OpType, double>(OpType.SUB, double.Parse(m.Groups["opd"].Value)));
							break;
						case "*":
							opList.Add(new KeyValuePair<OpType, double>(OpType.MULT, double.Parse(m.Groups["opd"].Value)));
							break;
						case "/":
							opList.Add(new KeyValuePair<OpType, double>(OpType.DIV, double.Parse(m.Groups["opd"].Value)));
							break;
						default:
							throw new ProgammShoudNotReachThisCodeError("_executeCommand switch default clause");
					}
				}
			}
			sr.Close();

			return opList;
		}

		public static void Save(string filename, List<KeyValuePair<OpType, double>> opList)
		{
			if (File.Exists(filename))
				throw new DataSaveException("File exists");

			StreamWriter wr;
			try
			{
				wr = new StreamWriter(filename);
			}
			catch (Exception e)
			{
				throw new DataSaveException(e.Message);
			}

			Console.WriteLine("Saving to file {0}", filename);
			foreach (var pair in opList)
			{
				OpType opType = pair.Key;
				double operand = pair.Value;

				switch (opType)
				{
					case OpType.INIT:
						wr.WriteLine(operand);
						break;
					case OpType.ADD:
						wr.WriteLine(string.Format("% + {0}", operand));
						break;
					case OpType.SUB:
						wr.WriteLine(string.Format("% - {0}", operand));
						break;
					case OpType.MULT:
						wr.WriteLine(string.Format("% * {0}", operand));
						break;
					case OpType.DIV:
						wr.WriteLine(string.Format("% / {0}]", operand));
						break;
					case OpType.GOTO:
						wr.WriteLine(string.Format("Out[{0}]", operand));
						break;
					default:
						throw new ProgammShoudNotReachThisCodeError("_executeCommand switch default clause");
				}
			}
			wr.Close();
			Console.WriteLine("Done.");
		}
	}
}