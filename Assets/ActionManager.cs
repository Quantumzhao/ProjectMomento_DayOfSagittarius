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
	private delegate void positionHandler(ref Vector2 position);
	private static positionHandler positionDelegate;

	private delegate void manipulationHandler(GameObject gameObject, params object[] param);
	private delegate void changeHandler(GameObject gameObject, manipulationHandler manipulation);
	private static event changeHandler change_Event;

	public static void ExecuteCommand(string command)
	{
		string[] commandList = command.ToUpper().Split(' ');

		switch (commandList[0])
		{
			case "POSN":
				positionDelegate = getPosition;
				break;

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

		switch (commandList[1])
		{
			case "CHNG":

				break;

			default:
				break;
		}
	}

	private static void getPosition(ref Vector2 position)
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
				manipulationHandler changePositionDelegate =
					(GameObject gameObject, object[] vs) => { };
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
