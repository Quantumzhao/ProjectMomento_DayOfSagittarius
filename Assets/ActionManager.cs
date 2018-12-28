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
	private delegate void changeHandler
		(object original, object data, manipulationHandler manipulation);
	private static changeHandler changeDelegate;

	private delegate void manipulationHandler(GameObject gameObject, object data);

	public static void ExecuteCommand(string command)
	{
		Queue<string> commandList = new Queue<string>(command.Split(' '));

		switch (commandList.Dequeue())
		{
			case "CHNG":
				change(commandList);
				break;

			default:
				break;
		}
	}

	private static void changePosition(Queue<string> commandList)
	{

	}

	private static void help(string param = "")
	{

	}

	private static void change(Queue<string> commandList)
	{
		switch (commandList.Dequeue())
		{
			case "POSN":
				position(commandList, out GameObject gameObject, out Vector2 coord);
				changeDelegate += 
				(
					object gameObject_Param, 
					object coord_Param, 
					manipulationHandler manipulation
				) => 
				{
					manipulation((GameObject)gameObject_Param, coord_Param);
				};
				changeDelegate
				(
					gameObject,
					coord,
					new manipulationHandler
					(
						(GameObject gameObject_Param, object coord_Param) =>
						{
							gameObject_Param.transform.position = (Vector3)coord_Param;
						}
					)
				);
				break;

			default:
				break;
		}
	}

	private static void position(Queue<string> commandList, out GameObject gameObject, out Vector2 coord)
	{
		/*changeHandler<Vector2> changeDelegate;
		manipulationHandler<Vector2> manipulationDelegate =
			(GameObject gameObject, Vector2 newPosition) =>
			{
				gameObject.transform.position = newPosition;
			};

		Vector2 position = new Vector2
		(
			float.Parse(commandList.Dequeue()),
			float.Parse(commandList.Dequeue())
		);*/

		gameObject = GameObject.Find(commandList.Dequeue());

		coord = new Vector2
		(
			float.Parse(commandList.Dequeue()),
			float.Parse(commandList.Dequeue())
		);
	}
}
