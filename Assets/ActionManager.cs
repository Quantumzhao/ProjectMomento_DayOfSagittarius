using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour {

	public void Awake()
	{

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
}
