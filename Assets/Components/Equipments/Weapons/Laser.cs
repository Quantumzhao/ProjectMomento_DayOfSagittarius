using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Components.Equipments;
using Assets.Components.Equipments.Weapons;

public class Laser : MonoBehaviour, IActivate, IWeapon
{
	private float bearing = 0;
	public float Bearing
	{
		get
		{
			return bearing;
		}

		set
		{
			if (value == 2 * Mathf.PI)
			{
				bearing = 0;
			}
			else
			{
				bearing = value;
			}
		}
	}

	public float Range
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public float SteeringRange()
	{
		throw new NotImplementedException();
	}

	bool IActivate.Activate()
	{
		return true;
	}
}
