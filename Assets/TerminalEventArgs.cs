using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TerminalEventArgs
{
	public TerminalEventArgs(string[] commands)
	{
		this.commands = new Queue<string>(commands);
	}

	private Queue<string> commands;

	private Dictionary<Type, Queue<Type>> arguments = new Dictionary<Type, Queue<Type>>();

	private bool Parser(string command, out Commands ParsedCommand)
	{
		switch (command)
		{
			case "POSN":
				ParsedCommand = Commands.POSN;
				break;

			case "CHNG":
				ParsedCommand = Commands.CHNG;
				break;

			case "HELP":
				ParsedCommand = Commands.HELP;
				break;

			case "MOVE":
				ParsedCommand = Commands.MOVE;
				break;

			case "ATTK":
				ParsedCommand = Commands.ATTK;
				break;

			case "SCAN":
				ParsedCommand = Commands.SCAN;
				break;

			case "EXIT":
				ParsedCommand = Commands.EXIT;
				break;

			case "PAUS":
				ParsedCommand = Commands.PAUS;
				break;

			default:
				ParsedCommand = 0;
				return false;
		}

		return true;
	}
}

public enum Commands
{
	POSN = 1,
	CHNG = 2,
	HELP = 3,

	MOVE = 4,
	ATTK = 5,
	SCAN = 6,
	INST = 7,

	EXIT = 8,
	PAUS = 9
}

