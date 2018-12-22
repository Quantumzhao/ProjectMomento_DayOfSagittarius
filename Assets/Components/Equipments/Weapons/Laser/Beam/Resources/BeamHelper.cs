using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamHelper : MonoBehaviour
{
	public float Length;

	public readonly float Dispersion = 0.01f;

	public float Orientation;

	public GameObject Beam;

	// Start is called before the first frame update
	void Start()
	{
		Length = 0f;
	}
}