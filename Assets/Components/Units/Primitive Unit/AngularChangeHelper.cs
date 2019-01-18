using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularChangeHelper : MonoBehaviour
{
	private Rigidbody2D rb2D;

	public const float MaxAngularAcceleration = 30;

	public void Awake()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	// Coroutine Method
    public IEnumerator ChangeAngle(Vector3 target, Vector3 initial)
	{
		while (gameObject.transform.eulerAngles != target)
		{
			float minAngle = MaxAngularAcceleration *
				Mathf.Pow(rb2D.angularVelocity / MaxAngularAcceleration, 2) / 2;

			Vector3 currentAngle = transform.eulerAngles;
			currentAngle.z = currentAngle.z > 180 ? currentAngle.z - 360 : currentAngle.z;

			Vector3 diffInAngle = target - currentAngle;

			if (diffInAngle.z > 180)
			{
				diffInAngle.z -= 360;
			}

			if (minAngle < Mathf.Abs(diffInAngle.z))
			{
				rb2D.angularVelocity += Mathf.Sign(diffInAngle.z) * MaxAngularAcceleration * Time.deltaTime;
			}
			else
			{
				rb2D.angularVelocity -= Mathf.Sign(diffInAngle.z) * MaxAngularAcceleration * Time.deltaTime;
			}

			yield return null;

		}
	}

	public void ChangeAngularVelocity(float target, float current)
	{

	}
}
