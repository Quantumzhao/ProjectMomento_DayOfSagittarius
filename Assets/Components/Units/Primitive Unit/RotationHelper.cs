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

	public void OnPointerDown(BaseEventData eventData)
	{
		PointerEventData data = (PointerEventData)eventData;

		faintColor = unitSpriteRenderer.color;
		faintColor.a = 0.5f;
	}

	public void OnDrag(BaseEventData eventData)
	{
		PointerEventData data = (PointerEventData)eventData;

		RectTransformUtility.ScreenPointToWorldPointInRectangle(
			(RectTransform)popMenuCanvas.transform,
			data.position,
			ResourceManager.Camera.GetComponent<Camera>(),
			out Vector3 localPoint
		);

		Vector3 rotation = new Vector3(0, 0, data.delta.x);

		unitSpriteRenderer.color = faintColor;

		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}

		totalRotation += rotation;

		gameObject.transform.eulerAngles = totalRotation;
	}

	public void OnPointerUp(BaseEventData eventData)
	{
		if (faintColor.a != 1)
		{
			faintColor.a = 1;

			behavior.isRotate = true;

			behavior.targetRotation = totalRotation + gameObject.transform.parent.rotation.eulerAngles;

			if (Mathf.Abs(behavior.targetRotation.z) > 360)
			{
				behavior.targetRotation.z %= 360f;
			}
		}

		unitSpriteRenderer.color = faintColor;

		gameObject.SetActive(false);
	}

	public void OnPointerExit()
	{

	}

	public void OnPointerEnter()
	{

	}
}
