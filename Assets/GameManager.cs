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
