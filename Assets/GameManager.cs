using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Flagship;

	public void UpdateFlagship(GameObject newFlagship)
	{
		Destroy(Flagship.GetComponent<Flagship>());

		newFlagship.AddComponent<Flagship>();

		Flagship = newFlagship;
	}
}
