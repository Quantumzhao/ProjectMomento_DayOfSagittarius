using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.PopMenuCanvas
{
	public class Behavior : MonoBehaviour
	{
		public void OnDrag(BaseEventData rawData)
		{
			PointerEventData data = (PointerEventData)rawData;

			if (data.button != PointerEventData.InputButton.Right)
			{
				return;
			}

			ResourceManager.Camera.transform.position -= (Vector3)data.delta / 100;
		}

		public void OnPointerDown(BaseEventData rawData)
		{
			PointerEventData data = (PointerEventData)rawData;

			ResourceManager.PopMenu.GetComponent<PopMenu.Behavior>().Close();

			ResourceManager.SelectedGameObject?.GetComponent<Unit.Behavior>().LostHighlight();

			ResourceManager.SelectedGameObject = null;
		}
	}
}
