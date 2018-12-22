using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Highlight
{
	public class Behavior : MonoBehaviour
	{
		public void Show()
		{
			gameObject.SetActive(true);

			gameObject.transform.position = ResourceManager.SelectedGameObject.transform.position;
		}

		public void Close()
		{
			gameObject.SetActive(false);
		}
	}
}