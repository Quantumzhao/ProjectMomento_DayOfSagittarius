using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Behavior : MonoBehaviour {

	public GameObject PopMenu;

	public GameObject Invoker;

	public void OnClick(BaseEventData rawData)
	{
		PopMenu.SetActive(false);
	}
}
