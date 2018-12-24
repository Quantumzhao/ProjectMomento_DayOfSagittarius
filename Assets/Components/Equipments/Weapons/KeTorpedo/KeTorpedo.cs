using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Equipments.Weapons;

public class KeTorpedo : MonoBehaviour, IWeapon
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

	float IWeapon.Range
	{
		get
		{
			throw new System.NotImplementedException();
		}
	}

	float IWeapon.SteeringRange
	{
		get
		{
			throw new System.NotImplementedException();
		}
	}

	public bool Activate()
	{
		Console.WriteLine("Boom");

		instantiateTorpedo(ResourceManager.SelectedGameObject);

		return true;
	}

	private void instantiateTorpedo(GameObject target)
	{

	}
}
