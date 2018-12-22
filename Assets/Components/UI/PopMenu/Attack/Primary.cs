using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UI.PopMenu;

public class Primary : MonoBehaviour
{
	public void OnPointerClick(BaseEventData rawData)
	{
		/*GameManager.SelectedGameObject
			.transform
			.GetChild(0)
			.GetChild(0)
			.GetChild(0)
			.gameObject
			.GetComponent<Laser>()
			.Activate();*/

		ResourceManager.SelectedGameObject.GetComponentInChildren<Laser>().Activate();
	}
}
