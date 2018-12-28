using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
///		Don't use this. 
/// </summary>
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


