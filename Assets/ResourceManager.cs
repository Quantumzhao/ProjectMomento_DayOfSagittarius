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
	public static GameObject Camera;

	private void Awake()
	{
		initConsole();
		initUnitHighlight();
		initPopMenu();
		initCamera();
	}

	public void Start()
	{
		Console.WriteLine("Set UnitHighlight Successful: " + UnitHighlight.name);
	}

	private void initConsole()
	{
		Console.TerminalOutput = GameObject.Find("Output").GetComponent<Text>();
		Console.InputField = GameObject.Find("Terminal")
							.transform
							.GetChild(2)
							.GetChild(1)
							.gameObject
							.GetComponent<Text>();
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

	private void initCamera()
	{
		Camera = GameObject.Find("Main Camera");
	}
}

public class Console
{
	public static Text TerminalOutput;
	public static Text InputField;

	public static void WriteLine(string message)
	{
		TerminalOutput.text += ("\n" + DateTime.Now.ToLongTimeString() + "\t" + message);
	}

	public static class Input
	{
		public static void Clear()
		{
			InputField.text = "";
		}
	}
}

public static class Constants
{
	public const float LightSpeed = 1f;
}

public struct Velocity
{
	public float Argument;
	public float Modulus;
}
