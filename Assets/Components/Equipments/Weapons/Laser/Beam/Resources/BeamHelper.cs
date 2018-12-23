using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BeamHelper : MonoBehaviour
{
	public float Length = 1f;
	public readonly float Dispersion = 0.01f;
	public Vector2 AnchorPoint;
	public Vector2 RectCoordVelocity;

	public GameObject Invoker;

	private Rigidbody2D rb2D;
	private LineRenderer lineRenderer;
	private Velocity v = new Velocity();

	// Start is called before the first frame update
	void Start()
	{
		v.Argument = Invoker.transform.rotation.z;

		v.Modulus = LightSpeed;

		RectCoordVelocity = new Vector2(
			v.Modulus * Mathf.Cos(v.Argument),
			v.Modulus * Mathf.Sin(v.Argument)
		);

		Length = 1f;

		rb2D = gameObject.GetComponent<Rigidbody2D>();

		rb2D.velocity = RectCoordVelocity;

		rb2D.position = Invoker.transform.position;

		lineRenderer = GetComponent<LineRenderer>();
	}

	public void Update()
	{
		AnchorPoint = rb2D.position;

		lineRenderer.SetPositions
		(
			new Vector3[]
			{
				new Vector3(AnchorPoint.x, 0.5f, 0f),
				new Vector3(AnchorPoint.x, -0.5f, 0f)
			}
		);
	}
}