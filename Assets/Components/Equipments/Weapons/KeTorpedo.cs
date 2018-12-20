using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Equipments;
using Assets.Components.Equipments.Weapons;

public class KeTorpedo : MonoBehaviour, IActivate, IWeapon
{
	public float Bearing
	{
		get
		{
			throw new System.NotImplementedException();
		}

		set
		{
			throw new System.NotImplementedException();
		}
	}

	public float Range()
	{
		throw new System.NotImplementedException();
	}

	public float SteeringRange()
	{
		throw new System.NotImplementedException();
	}

	public bool Activate()
	{
		return true;
	}
}
