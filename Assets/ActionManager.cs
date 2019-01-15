using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;
using CustomFunction;
using MiscUtilities;

public class ActionManager : MonoBehaviour {

	public void Awake()
	{
		initCursor();

		testModule(false);
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
		TestClass.ExecuteCommand(message);
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
	public static void ExecuteCommand(string message)
	{
		Queue<string> commandList = new Queue<string>(message.Split(' '));

		switch ((Commands)Enum.Parse(typeof(Commands), commandList.Dequeue().ToUpper()))
		{
			case Commands.CHNG:
				change(commandList);
				break;

			case Commands.HELP:
				break;

			case Commands.NEW:
				instantiate(commandList);
				break;

			case Commands.RFLC:
				Reflection(commandList);
				break;

			default:
				break;
		}

		Console.WriteLine(message);
		Console.Input.Clear();
	}

	private static void change(Queue<string> commandList)
	{
		switch ((Commands)Enum.Parse(typeof(Commands), commandList.Dequeue().ToUpper()))
		{
			case Commands.POSN:
				changePosition(commandList);
				break;

			case Commands.ROTN:
				changeRotation(commandList);
				break;
		}
	}

	private static void changePosition(Queue<string> commandList)
	{
		GameObject gameObject = GameObject.Find(commandList.Dequeue());

		Vector3 position = new Vector3
			(
				float.Parse(commandList.Dequeue()),
				float.Parse(commandList.Dequeue()),
				0
			);

		gameObject.transform.position = position;
	}

	private static void changeRotation(Queue<string> commandList)
	{
		GameObject gameObject = GameObject.Find(commandList.Dequeue());

		Vector3 rotation = new Vector3
			(	0,
				0,
				float.Parse(commandList.Dequeue())
			);

		gameObject.transform.eulerAngles = rotation;
	}

	private static void instantiate(Queue<string> commandList)
	{
		new GameObject(commandList.Dequeue());
	}

	private static void Reflection(Queue<string> commandList)
	{
		Type inputType = Type.GetType(commandList.Dequeue());
		ConstructorInfo typeConstructor = inputType.GetConstructor(Type.EmptyTypes);
		object inputClassObject = typeConstructor.Invoke(new object[] { });

		MethodInfo inputMethod = inputType.GetMethod(commandList.Dequeue());

		inputMethod.Invoke(inputClassObject, new object[] { });
	}
}

public class TestClass
{
	private static CustomFunctionWrapper instructions = new CustomFunctionWrapper();

	public static void ExecuteCommand(string command)
	{
		Queue<string> commandList = parse(command);

		if (!Enum.TryParse(commandList.Dequeue(), true, out Commands parsedCommand))
		{
			return;
		}

		switch (parsedCommand)
		{
			case Commands.CHNG:
				change(commandList);
				break;

			default:
				break;
		}

		instructions.Invoke();
	}

	private static void change(Queue<string> commandList)
	{
		#region check if the inputtext is a valid command or not. Written by Mike.Guo
		string inputCommand = commandList.Dequeue();
		
		// Contemporarily remove this module
		/*if (!isValidCommand(inputCommand))
		{
			return;
		}*/
		#endregion

		instructions.AddVariable("newProperty", null);
		instructions.AddVariable("GameObject", null);

		switch ((Commands)Enum.Parse(typeof(Commands), inputCommand))
		{
			case Commands.POSN:
				position(commandList);
				instructions.AddFunction
				(
					"Change",
					() =>
					{
						((GameObject)instructions["GameObject"]).transform.position
						= (Vector3)instructions["newProperty"];
						return null;
					}
				);
				break;

			case Commands.ROTN:
				break;

			default:
				break;
		}
	}

	private static void position(Queue<string> commandList)
	{
		instructions["GameObject"] = GameObject.Find(commandList.Dequeue());
		instructions["newProperty"] = new Vector3
			(
				float.Parse(commandList.Dequeue()),
				float.Parse(commandList.Dequeue()),
				0
			);

		if (float.TryParse(commandList.Dequeue(), out float result))
		{
			commandList.Dequeue();
		}
	}

	private static Queue<string> parse(string commands)
	{
		return new Queue<string>(commands.Split(' '));
	}

	// Mike.Guo	@	1/10/2019
	// Quantum	@	1/12/2019
	private static bool isValidCommand(string inputCommand, out Commands parsedCommand)
	{
		/*
		if (!Enum.TryParse(inputCommand, out Commands currentCommand))
		{
			Console.WriteLine($"{inputCommand} is not a valid command.");
			return false;
		}

		return true;
		*/

		if (!Enum.TryParse(inputCommand, true, out Commands newCommand))
		{
			Console.WriteLine($"{inputCommand} is not a valid command.");
			parsedCommand = newCommand;
			return false;
		}

		parsedCommand = newCommand;
		return true;
	}
}

public enum Commands
{
	#region Game controlling commands
		EXIT,   // Exit
		PAUS,   // Pause
	#endregion

	#region Instance methods of gameObjects
		MOVE,   // Move
		CHNG,   // Change
		ATTK,   // Attack
		SCAN,   // Scan
	#endregion

	#region Instance properties of gameObjects
		POSN,   // Position
		ROTN,   // Rotation
	#endregion

	#region Static commands
		HELP,   // Help
		NEW,    // Instantiate
		RFLC,	// Reflection
	#endregion
}

