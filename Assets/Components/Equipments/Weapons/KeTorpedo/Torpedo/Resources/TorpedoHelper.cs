using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class TorpedoHelper : MonoBehaviour
{
	private float alpha = 8f;   // Angular acceleration. NOTE: This is a numerical value

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
		/*
		 * 我为了在Unity里写这个孤儿追踪模块，已经花了三天了。什么成果都没有。
		 * 到现在为止一共提出过三个模型，要么用Unity写不出来，要么本身就有缺陷。
		 * 我承认，我是Unity新手，完全不熟悉框架，自己从头造轮子。
		 * 我的耐心已经被这个睿智玩意儿消磨完了，我TM不做了。
		 * 情怀？模拟？都TM狗屁。
		 * 我就暂且把这个应付的模型放这了，老子不干了。
		 * 要么哪位好心人打发慈悲帮我解决了这个智障模型，
		 * 要么我哪天又发昏自己重写这个模块。
		 */

		/*Vector2 diffInPos = Target.transform.position - gameObject.transform.position;

		float argument_CurrentVelocity = Mathf.Asin(rb2D.velocity.y / rb2D.velocity.magnitude);

		float argument_TargetVelocity = Mathf.Atan2(diffInPos.y, diffInPos.x);

		float diffInArgument = argument_TargetVelocity - argument_CurrentVelocity;

		float numericalSupplementaryVelocity = 2 * LightSpeed * Mathf.Sin(diffInArgument / 2);
		float absSV = Mathf.Abs(numericalSupplementaryVelocity);

		float argument_SupplementaryVelocity = argument_TargetVelocity - Mathf.PI / 2 - diffInArgument;

		rb2D.AddForce(
			new Vector2
			(
				alpha * Mathf.Cos(argument_SupplementaryVelocity),
				alpha * Mathf.Sin(argument_SupplementaryVelocity)
			)
		);*/

		Vector2 diffInPos = Target.transform.position - gameObject.transform.position;

		float argument_TargetVelocity = Mathf.Atan2(diffInPos.y, diffInPos.x);

		rb2D.velocity = new Vector2
		(
			LightSpeed * Mathf.Cos(argument_TargetVelocity),
			LightSpeed * Mathf.Sin(argument_TargetVelocity)
		);
	}

	private void initTransform()
	{
		gameObject.transform.position = Invoker.transform.position;
		gameObject.transform.rotation.eulerAngles.Set(0, 0, Invoker.transform.rotation.eulerAngles.z);
	}

	private void initVelocity()
	{
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

	/*/// <summary>
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
	}*/

	private Vector2 GuessTargetPosition()
	{
		/* THERE IS SOOOOO MUCH WORK TO DO!
		 * I'm just going to leave it blank 
		 * And expect someone with much enthusiasm to help me complete it
		*/

		throw new System.NotImplementedException();
	}
}
