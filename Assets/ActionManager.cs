using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionManager : MonoBehaviour {

	public void Awake()
	{
		initCursor();

		testModule(true);
	}

	public void UpdateFlagship(GameObject newFlagship)
	{
		Destroy(newFlagship.GetComponent<Flagship>());

		newFlagship.AddComponent<Flagship>();

		ResourceManager.Flagship = newFlagship;
	}

	private void initCursor()
	{
		Cursor.SetCursor(
			Resources.Load<Texture2D>("Normal"), 
			new Vector2(0f, 0f), 
			CursorMode.ForceSoftware
		);
	}

	public void ExecuteCommand(string message)
	{
		Command.ExecuteCommand(message);
	}

	private void testModule(bool isToggled = false)
	{
		if (!isToggled)
		{
			return;
		}

		#region TestSomeCode

		GameObject target = GameObject.Find("Target");

		target.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 0);

		#endregion
	}
}

public static class Command
{
	private delegate void manipulationHandler(TerminalEventArgs args);
	private delegate void changeHandler(manipulationHandler manipulation, TerminalEventArgs args);
	private static event changeHandler change_Event = 
	(manipulationHandler manipulation, TerminalEventArgs args) => 
	manipulation(args);

	public static void ExecuteCommand(string command)
	{
		string[] commandList = command.ToUpper().Split(' ');

		switch (commandList[0])
		{
			case "HELP":
				if (commandList.Length == 1)
				{
					help();
				}
				else
				{
					help(commandList[1]);
				}
				return;

			case "CHNG":
				changeSomething(commandList);
				break;

			default:
				break;
		}
	}

	private static void changePosition(TerminalEventArgs args)
	{

	}

	private static void help(string param = "")
	{

	}

	private static void changeSomething(string[] commandList)
	{
		switch (commandList[1])
		{
			case "POSN":
				change_Event
				(
					new manipulationHandler(changePosition), 
					new TerminalEventArgs
					(
						GameObject.Find(commandList[2]), 
						new Vector3
						(
							float.Parse(commandList[3]),
							float.Parse(commandList[4]),
							0f
						)
					)
				);
				break;

			default:
				break;
		}
	}

	public enum Commands
	{
		POSN,
		CHNG,
		HELP,

		MOVE,
		ATTK,
		SCAN,

		EXIT,
		PAUS
	}
}
