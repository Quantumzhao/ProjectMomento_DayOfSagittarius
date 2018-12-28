using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerationHelper : MonoBehaviour
{
	private float totalVelocity;

	private SpriteRenderer unitSpriteRenderer;
	private GameObject popMenuCanvas;

	private Color faintColor;

	private Unit.Behavior behavior;

	private void Start()
	{
		unitSpriteRenderer = gameObject.transform.parent.GetComponent<SpriteRenderer>();
		popMenuCanvas = GameObject.Find("PopMenuCanvas");
		behavior = gameObject.transform.parent.gameObject.GetComponent<Unit.Behavior>();
	}

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

		if (data.button != PointerEventData.InputButton.Right)
		{
			return;
		}

		// Make sure resource loading is called only once
		if (!cursorChanged)
		{
			Cursor.SetCursor(
				Resources.Load<Texture2D>("Accelerate"),
				new Vector2(0, 0),
				CursorMode.ForceSoftware
			);

			cursorChanged = true;
		}

		totalVelocity += data.delta.x;

		unitSpriteRenderer.color = faintColor;

		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}

	}

	public void OnPointerUp(BaseEventData eventData)
	{
		if (faintColor.a != 1)
		{
			faintColor.a = 1;

			behavior.isAccelerating = true;

			behavior.targetVelocity = totalVelocity + gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity.magnitude;
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
