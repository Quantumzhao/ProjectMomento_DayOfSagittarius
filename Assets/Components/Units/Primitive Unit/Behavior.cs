using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unit
{
	public class Behavior : MonoBehaviour
	{
		public void OnPointerClick(BaseEventData eventData)
		{
			PointerEventData data = (PointerEventData)eventData;

			ResourceManager.SelectedGameObject = gameObject;

			ResourceManager.UnitHighlight.GetComponent<UI.Highlight.Behavior>().Show();

			switch (data.button)
			{
				case PointerEventData.InputButton.Left:
					enableDragHandler(true);
					break;

				case PointerEventData.InputButton.Right:
					ResourceManager.PopMenu.GetComponent<UI.PopMenu.Behavior>().Show();
					break;

				case PointerEventData.InputButton.Middle:
					break;

				default:
					break;
			}
		}

		

		public void LostHighlight()
		{
			enableDragHandler(false);

			ResourceManager.UnitHighlight.GetComponent<UI.Highlight.Behavior>().Close();
		}

		private void enableDragHandler(bool value)
		{
			GetComponents<CircleCollider2D>()[1].enabled = value;
		}

		private void changeRotation()
		{

		}
	}
}