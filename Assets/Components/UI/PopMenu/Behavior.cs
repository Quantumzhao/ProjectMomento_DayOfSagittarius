using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.PopMenu
{
	public class Behavior : MonoBehaviour
	{
		public void Close()
		{
			gameObject.SetActive(false);
		}

		public void Show()
		{
			gameObject.transform.position = ResourceManager.SelectedGameObject.transform.position;

			gameObject.SetActive(true);
		}
	}
}
