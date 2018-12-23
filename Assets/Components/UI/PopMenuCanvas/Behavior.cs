using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.PopMenuCanvas
{
	public class Behavior : MonoBehaviour
	{
		private Vector2 pointerOffset;

		public void OnPointerClick(BaseEventData eventData)
		{
			PointerEventData data = (PointerEventData)eventData;

			ResourceManager.UnitHighlight.GetComponent<Highlight.Behavior>().Close();
			ResourceManager.PopMenu.GetComponent<PopMenu.Behavior>().Close();
		}

		public void OnDrag(BaseEventData rawData)
		{
			PointerEventData data = (PointerEventData)rawData;

			if (data.button != PointerEventData.InputButton.Right)
			{
				return;
			}

			Vector2 localPosition;

			RectTransformUtility.ScreenPointToLocalPointInRectangle(
				(RectTransform)gameObject.transform,
				data.position,
				data.pressEventCamera,
				out localPosition
			);

			{
				ResourceManager.Camera.transform.position = localPosition - pointerOffset;
			}
		}

		public void OnPointerDown(BaseEventData rawData)
		{
			PointerEventData data = (PointerEventData)rawData;

			RectTransformUtility.ScreenPointToLocalPointInRectangle(
				(RectTransform)gameObject.transform,
				data.position,
				data.pressEventCamera,
				out pointerOffset
			);

			Console.WriteLine(data.position.ToString());
			Console.WriteLine(pointerOffset.ToString());
		}
	}

	
}
