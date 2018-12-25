using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Equipments;

public class Radar : MonoBehaviour, IActivate
{
	public bool Activate()
	{
		Console.WriteLine("Radar Activated");

		instantiateEMWave(ResourceManager.SelectedGameObject);

		return true;
	}

	private void instantiateEMWave(GameObject invoker)
	{
		GameObject emWave = Instantiate((GameObject)Resources.Load("EMWave"));

		emWave.GetComponent<EMWaveHelper>().Invoker = invoker;
	}
}
