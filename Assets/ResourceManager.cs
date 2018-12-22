using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResourceManager : MonoBehaviour
{
	public static GameObject UnitHighlight;
	public static GameObject Flagship;
	public static GameObject SelectedGameObject;
	public static GameObject PopMenu;

	private void Awake()
	{
		initConsole();
		initUnitHighlight();
		initPopMenu();
	}

	public void Start()
	{
		Console.WriteLine("Set UnitHighlight Successful: " + UnitHighlight.name);
	}

	private void initConsole()
	{
		Console.TerminalOutput = GameObject.Find("Output").GetComponent<Text>();
	}

	private void initUnitHighlight()
	{
		UnitHighlight = new GameObject("Highlight");

		SpriteRenderer spriteRenderer = UnitHighlight.AddComponent<SpriteRenderer>();

		spriteRenderer.sprite = Resources.Load<Sprite>("Highlight_Selection");

		UnitHighlight.SetActive(false);

		UnitHighlight.AddComponent<UI.Highlight.Behavior>();
	}

	private void initPopMenu()
	{
		PopMenu = GameObject.Find("PopMenu");

		PopMenu.SetActive(false);
	}
}

public class Console
{
	public static Text TerminalOutput;

	public static void WriteLine(string message)
	{
		TerminalOutput.text += ("\n" + DateTime.Now.ToLongTimeString() + "\t" + message);
	}
}
