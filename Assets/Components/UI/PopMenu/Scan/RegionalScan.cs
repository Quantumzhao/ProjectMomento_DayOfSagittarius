using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RegionalScan : MonoBehaviour
{
	private GameObject invoker;

    public void OnPointerClick(BaseEventData rawData)
	{
		invoker = transform.parent.parent.GetComponent<Behavior>().Invoker;

		invoker
			.transform
			.GetChild(0)
			.GetChild(1)
			.gameObject
			.GetComponent<Radar>()
			.Activate();
	}
}
