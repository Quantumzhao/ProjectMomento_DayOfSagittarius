using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class TorpedoHelper : MonoBehaviour
{
	private Velocity v = new Velocity();
	private Vector2 RectCoordVelocity;
	private float alpha = 15f;	// Angular acceleration
	private float omega = 0f;	// Angular velocity
	private float theta;		// Anglular Displacement

	private Rigidbody2D rb2D;
	private Radar radar;

	public GameObject Target;
	public GameObject Invoker;

	// Start is called before the first frame update
    void Start()
    {
		initTransform();
		initVelocity();
		initRigidBody2D();
		initRadar();
    }

    // Update is called once per frame
    void Update()
    {
		if (DrunkardAlgorithm())
		{
			omega += alpha;
		}
		else
		{
			omega -= alpha;
		}

		RectCoordVelocity = new Vector2
		(
			v.Modulus * Mathf.Cos(Mathf.Deg2Rad * omega),
			v.Modulus * Mathf.Cos(Mathf.Deg2Rad * omega)
		);

		rb2D.velocity = RectCoordVelocity;
    }

	private void initTransform()
	{
		gameObject.transform.position = Invoker.transform.position;
		gameObject.transform.rotation.eulerAngles.Set(0, 0, Invoker.transform.rotation.eulerAngles.z);
	}

	private void initVelocity()
	{
		v.Argument = Invoker.transform.rotation.eulerAngles.z;

		v.Modulus = LightSpeed;

		RectCoordVelocity = new Vector2(
			v.Modulus * Mathf.Cos(Mathf.Deg2Rad * v.Argument),
			v.Modulus * Mathf.Sin(Mathf.Deg2Rad * v.Argument)
		);
	}

	private void initRigidBody2D()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();

		rb2D.velocity = RectCoordVelocity;
	}

	private void initRadar()
	{
		radar = gameObject.GetComponent<Radar>();
	}

	/// <summary>
	///		Haven't UNFINISHED yest, may include tons of bug
	/// </summary>
	/// <returns>
	///		<see cref="Velocity"/>
	///		true: Sign of the angular acceleration should not be changed
	///		false: vice versa
	/// </returns>
	private bool DrunkardAlgorithm()
	{
		Vector2 diffInPos = Target.transform.position - gameObject.transform.position;

		float diffInTheta = Mathf.Tan(diffInPos.y / diffInPos.x);

		float minTheta = omega * Mathf.Sqrt(Mathf.Abs(2 * diffInTheta / alpha));

		if (Mathf.Abs(minTheta) < Mathf.Abs(diffInTheta))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private Vector2 GuessTargetPosition()
	{
		/* THERE IS SOOOOO MUCH WORK TO DO!
		 * I'm just going to leave it blank 
		 * And expect someone with much enthusiasm to help me complete it
		*/

		throw new System.NotImplementedException();
	}
}
