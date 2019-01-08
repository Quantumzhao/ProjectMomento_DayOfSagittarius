using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationHelper : MonoBehaviour
{
	private SpriteRenderer unitSpriteRenderer;
	private GameObject popMenuCanvas;

	private Color faintColor;

	private Vector3 totalRotation = new Vector3();

	private Unit.Behavior behavior;

	private void Start()
	{
		unitSpriteRenderer = gameObject.transform.parent.GetComponent<SpriteRenderer>();
		popMenuCanvas = GameObject.Find("PopMenuCanvas");
		behavior = gameObject.transform.parent.gameObject.GetComponent<Unit.Behavior>();
	}

	[System.Obsolete("Use Behavior.OnPointerDown()")]
	public void OnPointerDown(BaseEventData eventData)
	{
		PointerEventData data = (PointerEventData)eventData;

		faintColor = unitSpriteRenderer.color;
		faintColor.a = 0.5f;
	}

	private bool cursorChanged = false;
	public void OnDrag(BaseEventData eventData)
	{
		PointerEventData data = (PointerEventData)eventData;

		if (data.button != PointerEventData.InputButton.Left)
		{
			return;
		}

		// Make sure resource loading is called only once
		if (!cursorChanged)
		{
			Cursor.SetCursor(
				Resources.Load<Texture2D>("Rotate"),
				new Vector2(0, 0), 
				CursorMode.ForceSoftware
			);

			cursorChanged = true;
		}

		Vector3 rotation = new Vector3(0, 0, data.delta.x);

		unitSpriteRenderer.color = faintColor;

		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}

		totalRotation += rotation;

		gameObject.transform.eulerAngles = totalRotation;
	}

	[System.Obsolete("Use Behavior.OnPointerUp()")]
	public void OnPointerUp(BaseEventData eventData)
	{
		if (faintColor.a != 1)
		{
			faintColor.a = 1;

			behavior.IsRotating = true;

			behavior.TargetRotation = (totalRotation + gameObject.transform.parent.rotation.eulerAngles).z;

			if (Mathf.Abs(behavior.TargetRotation) > 360)
			{
				behavior.TargetRotation %= 360f;
			}
		}

		unitSpriteRenderer.color = faintColor;

		if (cursorChanged)
		{
			Cursor.SetCursor(
				Resources.Load<Texture2D>("Normal"),
				new Vector2(0f, 0f),
				CursorMode.ForceSoftware
			);

			cursorChanged = false;
		}

		gameObject.SetActive(false);
	}
}
