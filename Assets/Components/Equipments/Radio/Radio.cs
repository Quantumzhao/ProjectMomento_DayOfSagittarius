using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Equipments;

public class Radio : MonoBehaviour, IActivate
{
	public bool Activate()
	{
		Console.WriteLine("Radio Transmission Initiated");

		return true;
	}
}
