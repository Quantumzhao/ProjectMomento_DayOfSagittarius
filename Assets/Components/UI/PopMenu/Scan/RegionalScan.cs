using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RegionalScan : MonoBehaviour
{
    public void OnPointerClick(BaseEventData rawData)
	{
		/*GameManager.SelectedGameObject
			.transform
			.GetChild(0)
			.GetChild(1)
			.gameObject
			.GetComponent<Radar>()
			.Activate();*/

		ResourceManager.SelectedGameObject.GetComponentInChildren<Radar>().Activate();
	}
}
