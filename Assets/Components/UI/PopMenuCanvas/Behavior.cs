using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.PopMenuCanvas
{
	public class Behavior : MonoBehaviour
	{
		//private delegate void dragHandler(PointerEventData data);
		//private dragHandler dragDelegate;

		public void OnDrag(BaseEventData rawData)
		{
			PointerEventData data = (PointerEventData)rawData;

			switch (data.button)
			{
				case PointerEventData.InputButton.Left:

					break;

				case PointerEventData.InputButton.Right:
					moveCamera(data);
					break;

				case PointerEventData.InputButton.Middle:
					break;

				default:
					break;
			}

		}

		public void OnPointerDown(BaseEventData rawData)
		{
			PointerEventData data = (PointerEventData)rawData;

			switch (data.button)
			{
				case PointerEventData.InputButton.Left:
					cancelSelection(data);
					break;

				case PointerEventData.InputButton.Right:

					break;

				case PointerEventData.InputButton.Middle:
					break;

				default:
					break;
			}
		}

		private void moveCamera(PointerEventData data)
		{
			ResourceManager.Camera.transform.position -= (Vector3)data.delta / 100;
		}

		private void cancelSelection(PointerEventData data)
		{
			ResourceManager.PopMenu.GetComponent<PopMenu.Behavior>().Close();

			ResourceManager.SelectedGameObject?.GetComponent<Unit.Behavior>().LostHighlight();

			ResourceManager.SelectedGameObject = null;
		}

		private void PlanningRoute()
		{

		}
	}
}
