﻿using System.Collections;
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

	private float range;
	public float Range
	{
		get
		{
			return range;
		}

		private set
		{
			range = value;
		}
	}

	private float steeringRange;
	public float SteeringRange
	{
		get
		{
			return steeringRange;
		}

		private set
		{
			steeringRange = value;
		}
	}

	bool IActivate.Activate()
	{
		return true;
	}
}
