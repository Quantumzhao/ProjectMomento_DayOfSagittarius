using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Equipments;

public class Radar : MonoBehaviour, IActivate
{
	public bool Activate()
	{
		Console.WriteLine("Radar Activated");

		return true;
	}
}
