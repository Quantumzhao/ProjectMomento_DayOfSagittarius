using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unit
{
	public class Behavior : MonoBehaviour
	{
		private GameObject popMenuCanvas;
		private RotationHelper rotationHelper;
		private VelocityHelper accelerationHelper;

		private float angularAcceleration = 30;
		private float accelerarion = 30;

		public Vector3 TargetRotation;
		public bool IsRotating;

		public float targetVelocity;
		public bool isAccelerating;

		private Rigidbody2D rb2D;

		public void Start()
		{
			popMenuCanvas = GameObject.Find("PopMenuCanvas");

			rb2D = gameObject.GetComponent<Rigidbody2D>();

			IsRotating = false;
			isAccelerating = false;
		}

		public void FixedUpdate()
		{
			if (IsRotating)
			{
				float currentAngle = transform.eulerAngles.z;
				currentAngle = currentAngle > 180 ? currentAngle - 360 : currentAngle;

				if (Mathf.Abs(currentAngle - TargetRotation.z) > 1)
				{
					changeRotation();
				}
				else
				{
					IsRotating = false;

					rb2D.angularVelocity = 0;
				}
			}
		}

		public void OnPointerEnter(BaseEventData eventData)
		{

		}

		public void OnPointerLeave(BaseEventData eventData)
		{

		}

		public void OnPointerDown(BaseEventData eventData)
		{

		}

		public void OnPointerUp(BaseEventData eventData)
		{

		}

		public void OnPointerClick(BaseEventData eventData)
		{
			PointerEventData data = (PointerEventData)eventData;

			ResourceManager.SelectedGameObject = gameObject;

			ResourceManager.UnitHighlight.GetComponent<UI.Highlight.Behavior>().Show();

			switch (data.button)
			{
				case PointerEventData.InputButton.Left:
					enableDragHandler(true);
					break;

				case PointerEventData.InputButton.Right:
					ResourceManager.PopMenu.GetComponent<UI.PopMenu.Behavior>().Show();
					break;

				case PointerEventData.InputButton.Middle:
					break;

				default:
					break;
			}
		}

		public void OnPointerDrag(BaseEventData eventData)
		{
			PointerEventData data = (PointerEventData)eventData;

			switch (data.button)
			{
				case PointerEventData.InputButton.Left:
					break;

				case PointerEventData.InputButton.Right:
					break;

				case PointerEventData.InputButton.Middle:
					break;
				default:
					break;
			}
		}

		public void LostHighlight()
		{
			enableDragHandler(false);

			ResourceManager.UnitHighlight.GetComponent<UI.Highlight.Behavior>().Close();
		}

		private void enableDragHandler(bool value)
		{
			GetComponents<CircleCollider2D>()[1].enabled = value;
		}

		private void changeRotation()
		{
			float minAngle = angularAcceleration * 
				Mathf.Pow(rb2D.angularVelocity / angularAcceleration, 2) / 2;

			float currentAngle = transform.eulerAngles.z;
			currentAngle = currentAngle > 180 ? currentAngle - 360 : currentAngle;

			float diffInAngle = TargetRotation.z - currentAngle;

			if (diffInAngle > 180)
			{
				diffInAngle -= 360;
			}

			if (minAngle < Mathf.Abs(diffInAngle))
			{
				rb2D.angularVelocity += Mathf.Sign(diffInAngle) *  angularAcceleration * Time.deltaTime;
			}
			else
			{
				rb2D.angularVelocity -= Mathf.Sign(diffInAngle) * angularAcceleration * Time.deltaTime;
			}
		}

		private void changeAcceleration()
		{

		}
	}
}