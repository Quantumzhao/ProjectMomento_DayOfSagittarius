using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Behavior : MonoBehaviour {

	public GameObject PopMenu;

	public GameObject Invoker;

	public void CloseMenu(BaseEventData rawData)
	{
		PopMenu.SetActive(false);

		GameObject highlight = GameObject.Find("Highlight");

		if (highlight != null)
		{
			highlight.SetActive(false);
		}
	}
}
