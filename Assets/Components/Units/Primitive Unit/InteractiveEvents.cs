using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InteractiveEvents : MonoBehaviour {

	public Transform PopMenuCanvas;

	public GameObject PopMenu;

	public GameObject Unit;

	private GameObject highlight;

	public void Awake()
	{
		highlight = new GameObject("Highlight");

		highlight.AddComponent<SpriteRenderer>();

		highlight.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Highlight_Selection");

		highlight.transform.localScale = new Vector3(0.5f, 0.5f, 0f);

		highlight.transform.SetParent(PopMenuCanvas);

		highlight.SetActive(false);
	}

	public void OnPointerClick(BaseEventData rawData)
	{
		PointerEventData data = (PointerEventData)rawData;

		enableHighlight();

		if (data.button == PointerEventData.InputButton.Right)
		{
			showPopMenu();
		}
	}

	private void enableHighlight()
	{
		if (highlight != null)
		{
			highlight.transform.position = Unit.transform.position;

			highlight.SetActive(true);
		}
	}

	private void showPopMenu()
	{
		PopMenu.transform.position = Unit.transform.position;

		PopMenu.SetActive(true);

		PopMenu.GetComponent<Behavior>().Invoker = Unit;
	}
}
