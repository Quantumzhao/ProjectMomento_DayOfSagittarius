﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InteractiveEvents : MonoBehaviour {

	public Transform PopMenuCanvas;

	public GameObject PopMenu;

	public Transform Unit;

	public void OnPointerClick(BaseEventData rawData)
	{
		PointerEventData data = (PointerEventData)rawData;

		if (data.button == PointerEventData.InputButton.Right)
		{
			PopMenu.transform.position = Unit.position;

			PopMenu.SetActive(true);
		}
	}
}
