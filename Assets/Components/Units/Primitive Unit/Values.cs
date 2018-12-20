using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{

	/*
	 * Each unit has the following properties
	 * (Only in DEMO 0)
	*/

	private float hp = 100f;
	public float HP
	{
		get
		{
			return hp;
		}

		set
		{
			if (value <= 100 && value >= 0)
			{
				hp = value;
			}
		}
	}

	private int maxStaff;		// Leave it blank temporarily
	private int staff = 100;
	public int Staff
	{
		get
		{
			return staff;
		}

		set
		{
			if (value >= 0)
			{
				staff = value;
			}
		}
	}

	private float maxFuel;		// Leave it blank temporarily
	private float fuel = 100;
	public float Fuel
	{
		get
		{
			return fuel;
		}

		set
		{
			if (value >= 0)
			{
				fuel = value;
			}
		}
	}
}
