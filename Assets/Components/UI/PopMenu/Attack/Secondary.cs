using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Secondary : MonoBehaviour
{
    public void OnPointerClick(BaseEventData rawData)
	{
		/*GameManager.SelectedGameObject
			.transform
			.GetChild(0)
			.GetChild(0)
			.GetChild(1)
			.gameObject
			.GetComponent<KeTorpedo>()
			.Activate();*/

		ResourceManager.SelectedGameObject.GetComponentInChildren<KeTorpedo>().Activate();
	}
}
