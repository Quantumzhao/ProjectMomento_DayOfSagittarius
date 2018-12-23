using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHelper : MonoBehaviour
{

	private Vector2 pointerOffset;

	public RectTransform canvasRectTransform;
	public RectTransform windowRectTransform;

	public void OnDrag(BaseEventData data)
	{
		PointerEventData eventData = (PointerEventData)data;

		Vector2 pointerPosition = ClampToWindow(eventData);

		Vector2 localPointerPosition;

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
			canvasRectTransform,
			pointerPosition,
			eventData.pressEventCamera,
			out localPointerPosition)
		)
		{
			windowRectTransform.localPosition = localPointerPosition - pointerOffset;
		}
	}

	public void OnPointerDown(BaseEventData data)
	{
		PointerEventData eventData = (PointerEventData)data;

		transform.parent.SetAsLastSibling();
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			windowRectTransform,
			eventData.position,
			eventData.pressEventCamera,
			out pointerOffset);
	}

	private Vector2 ClampToWindow(PointerEventData eventData)
	{
		Vector2 rawPointerPosition = eventData.position;

		Vector3[] canvasCorners = new Vector3[4];

		canvasRectTransform.GetWorldCorners(canvasCorners);

		float clampedX = Mathf.Clamp(rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
		float clampedY = Mathf.Clamp(rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

		Vector2 newPointerPosition = new Vector2(clampedX, clampedY);

		return newPointerPosition;
	}
}