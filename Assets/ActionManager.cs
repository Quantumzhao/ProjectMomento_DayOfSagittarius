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
}

public static class Command
{
	private delegate void positionHandler(ref Vector2 position);
	private static positionHandler positionDelegate;

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
