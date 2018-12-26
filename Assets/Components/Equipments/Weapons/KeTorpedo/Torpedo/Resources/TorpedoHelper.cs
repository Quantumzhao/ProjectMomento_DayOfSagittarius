using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class TorpedoHelper : MonoBehaviour
{
	private Velocity v = new Velocity();
	private Vector2 RectCoordVelocity;
	private float alpha = 8f;   // Angular acceleration. NOTE: This is a numerical value
								//private float omega = 0f;	// Angular velocity
								//private float theta;		// Anglular Displacement

	private float thrust = 0.1f;

	private Rigidbody2D rb2D;
	private Radar radar;

	public GameObject Target;
	public GameObject Invoker;

	// Start is called before the first frame update
    void Start()
    {
		initTransform();
		initRigidBody2D();
		initVelocity();
		initRadar();
		initTarget();
    }

    void FixedUpdate()
    {
		//v.Argument = rb2D.rotation;

		/*if (DrunkardAlgorithm())
		{
			rb2D.angularVelocity += Mathf.Sign(rb2D.angularVelocity) * alpha * Time.deltaTime;
		}
		else
		{
			rb2D.angularVelocity -= Mathf.Sign(rb2D.angularVelocity) * alpha * Time.deltaTime;
		}

		//v.Argument += omega * Time.deltaTime;

		RectCoordVelocity = new Vector2
		(
			v.Modulus * Mathf.Cos(Mathf.Deg2Rad * v.Argument),
			v.Modulus * Mathf.Sin(Mathf.Deg2Rad * v.Argument)
		);

		rb2D.velocity = RectCoordVelocity;*/

		

		Vector2 diffInPos = Target.transform.position - gameObject.transform.position;

		float diffInTheta = Mathf.Atan2(diffInPos.y, diffInPos.x) * Mathf.Rad2Deg - rb2D.rotation;

		float minTheta = alpha * Mathf.Pow(rb2D.angularVelocity / alpha, 2) / 2;

		if (Mathf.Abs(minTheta) < Mathf.Abs(diffInTheta))
		{
			rb2D.AddTorque(Mathf.Sign(rb2D.angularVelocity) * alpha);
		}
		else
		{
			rb2D.AddTorque(-Mathf.Sign(rb2D.angularVelocity) * alpha);
		}

		rb2D.AddForce(transform.up * thrust);
	}

	private void initTransform()
	{
		gameObject.transform.position = Invoker.transform.position;
		gameObject.transform.rotation.eulerAngles.Set(0, 0, Invoker.transform.rotation.eulerAngles.z);
	}

	private void initVelocity()
	{
		/*v.Argument = Invoker.transform.rotation.eulerAngles.z;

		v.Modulus = LightSpeed;

		RectCoordVelocity = new Vector2(
			v.Modulus * Mathf.Cos(Mathf.Deg2Rad * v.Argument),
			v.Modulus * Mathf.Sin(Mathf.Deg2Rad * v.Argument)
		);*/

		rb2D.velocity = new Vector2(LightSpeed, 0);
	}

	private void initRigidBody2D()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	private void initRadar()
	{
		radar = gameObject.GetComponent<Radar>();
	}

	private void initTarget()
	{
		Target = GameObject.Find("Target");
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

		float diffInTheta = Mathf.Atan2(diffInPos.y, diffInPos.x) * Mathf.Rad2Deg - rb2D.rotation;

		float minTheta = alpha * Mathf.Pow(rb2D.angularVelocity / alpha, 2) / 2;

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
