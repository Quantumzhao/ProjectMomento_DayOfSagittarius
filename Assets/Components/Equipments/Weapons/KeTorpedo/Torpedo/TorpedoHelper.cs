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

	public GameObject Target;
	public GameObject Invoker;

	// Start is called before the first frame update
    void Start()
    {
		initTransform();
		initVelocity();
		initRigidBody2D();
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

	/// <summary>
	///		UNFINISHED, may include tons of bug
	/// </summary>
	/// <returns>
	///		true: Sign of angular acceleration should not be changed
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
}
