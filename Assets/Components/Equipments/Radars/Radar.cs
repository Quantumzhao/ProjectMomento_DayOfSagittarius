using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Equipments;

public class Radar : MonoBehaviour, IActivate
{
	public bool Activate(Transform invoker_transform)
	{
		GameManager.WriteLine("Radar Activated");

		return true;
	}
}
