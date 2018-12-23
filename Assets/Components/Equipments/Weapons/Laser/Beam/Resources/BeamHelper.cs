using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BeamHelper : MonoBehaviour
{
	public readonly float Dispersion = 15f;
	public Vector2 AnchorPoint;
	public Vector2 RectCoordVelocity;

	public GameObject Invoker;

	private BoxCollider2D boxCollider2D;
	private Rigidbody2D rb2D;
	private LineRenderer lineRenderer;
	private Velocity v = new Velocity();
	private float halfLength = 0f;
	public float halfDispersion;
	private float traversedTime;

	// Start is called before the first frame update
	void Start()
	{
		initDispersion();
		initVelocity();
		initRigidBody2D();
		initBoxCollider2D();
		initTransform();
		initLineRenderer();		
	}

	public void Update()
	{
		AnchorPoint = gameObject.transform.position;

		traversedTime += Time.deltaTime;

		halfLength = traversedTime * LightSpeed * halfDispersion / 100;

		boxCollider2D.size.Set(0.05f, 2 * halfLength);

		Vector2 start = new Vector2
		(
			AnchorPoint.x + halfLength * Mathf.Sin(Mathf.Deg2Rad * v.Argument),
			AnchorPoint.y - halfLength * Mathf.Cos(Mathf.Deg2Rad * v.Argument)
		);

		Vector2 end = new Vector2
		(
			AnchorPoint.x - halfLength * Mathf.Sin(Mathf.Deg2Rad * v.Argument),
			AnchorPoint.y + halfLength * Mathf.Cos(Mathf.Deg2Rad * v.Argument)
		);

		lineRenderer.SetPositions
		(
			new Vector3[]
			{
				new Vector3(start.x, start.y, 0f),
				new Vector3(end.x, end.y, 0f)
			}
		);
	}

	private void initDispersion()
	{
		halfDispersion = Dispersion / 2;
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

	private void initBoxCollider2D()
	{
		boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
		boxCollider2D.size.Set(0.05f, 0.0001f);
	}

	private void initTransform()
	{
		gameObject.transform.position = Invoker.transform.position;
		gameObject.transform.rotation.eulerAngles.Set(0, 0, Invoker.transform.rotation.eulerAngles.z);
	}

	private void initLineRenderer()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}
}