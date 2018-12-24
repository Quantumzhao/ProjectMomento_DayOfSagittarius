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

	public bool Activate(GameObject target)
	{
		instantiateTorpedo(ResourceManager.SelectedGameObject, target);

		return true;
	}

	private void instantiateTorpedo(GameObject invoker, GameObject target = null)
	{
		GameObject torpedo = Instantiate((GameObject)Resources.Load("Torpedo"));

		TorpedoHelper torpedoHelper = torpedo.GetComponent<TorpedoHelper>();

		torpedoHelper.Invoker = invoker;
		torpedoHelper.Target = target;
	}
}
