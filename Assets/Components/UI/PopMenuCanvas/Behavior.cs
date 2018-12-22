using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.PopMenuCanvas
{
	public class Behavior : MonoBehaviour
	{
		public void OnPointerClick(BaseEventData eventData)
		{
			PointerEventData data = (PointerEventData)eventData;

			ResourceManager.UnitHighlight.GetComponent<Highlight.Behavior>().Close();
			ResourceManager.PopMenu.GetComponent<PopMenu.Behavior>().Close();
		}
	}
}
