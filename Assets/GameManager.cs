using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject Flagship;

	private static Text TerminalOutput;

	private void Awake()
	{
		TerminalOutput = GameObject.Find("Output").GetComponent<Text>();

		Cursor.SetCursor(Resources.Load<Texture2D>("Normal"), new Vector2(0f, 0f), CursorMode.ForceSoftware);
	}

	public void UpdateFlagship(GameObject newFlagship)
	{
		Destroy(Flagship.GetComponent<Flagship>());

		newFlagship.AddComponent<Flagship>();

		Flagship = newFlagship;
	}

	public static void WriteLine(string message)
	{
		TerminalOutput.text += ("\n" + DateTime.Now.ToLongTimeString() + "\t\t" + message);
	}
}
