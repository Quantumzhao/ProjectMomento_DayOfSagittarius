using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameCursor;

namespace Unit
{
	public class Behavior : MonoBehaviour
	{
		private GameObject popMenuCanvas;
		private GameObject spriteWhenDragging;

		private float angularAcceleration = 30;
		private float accelerarion = 30;

		private float targetRotation;
		public float TargetRotation
		{
			get
			{
				return targetRotation;
			}

			set
			{
				if (Mathf.Abs(value) >= 360f)
				{
					value -= 360f;
				}

				targetRotation = value;
			}
		}

		private float targetVelocity;
		public float TargetVelocity
		{
			get
			{
				return targetVelocity;
			}

			set
			{
				targetVelocity = value;
			}
		}

		public bool IsRotating;
		public bool isAccelerating;

		private Rigidbody2D rb2D;

		private Color transparentColor;
		private SpriteRenderer spriteRenderer;		// The spriteRenderer of the unit

		private CursorStatus cursorStatus = CursorStatus.Normal;

		public void Start()
		{
			popMenuCanvas = GameObject.Find("PopMenuCanvas");
			spriteWhenDragging = gameObject
								.transform
								.GetChild(0)
								.gameObject;

			rb2D = gameObject.GetComponent<Rigidbody2D>();
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

			IsRotating = false;
			isAccelerating = false;
		}

		public void FixedUpdate()
		{
			if (IsRotating)
			{
				float currentAngle = transform.eulerAngles.z;
				currentAngle = currentAngle > 180 ? currentAngle - 360 : currentAngle;

				if (Mathf.Abs(currentAngle - TargetRotation) > 1)
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
			#region Set cursor appearance to undetermined
			ResourceManager.Cursor.Mode = CursorStatus.Undetermined;
			#endregion
		}

		public void OnPointerLeave(BaseEventData eventData)
		{
			#region Set cursor appearance to normal
			ResourceManager.Cursor.Mode = CursorStatus.Normal;
			#endregion
		}

		public void OnPointerDown(BaseEventData eventData)
		{
			#region Prepare for dragging the unit
			PointerEventData data = (PointerEventData)eventData;

			transparentColor = spriteRenderer.color;
			transparentColor.a = 0.5f;
			#endregion
		}

		public void OnPointerUp(BaseEventData eventData)
		{
			#region Submit all changes
			var r = transform.eulerAngles.z * Mathf.Deg2Rad;
			rb2D.velocity = new Vector2
				(
					targetVelocity * Mathf.Cos(r),
					targetVelocity * Mathf.Sin(r)
				);
			#endregion

			#region Revert the environment
			ResourceManager.Cursor.Mode = CursorStatus.Normal;
			#endregion
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
					setTargetRotation(data);
					break;

				case PointerEventData.InputButton.Right:
					setTargetVelocity(data);
					break;

				case PointerEventData.InputButton.Middle:
					break;

				default:
					break;
			}

			var r = spriteWhenDragging.transform.eulerAngles.z;
			spriteWhenDragging.transform.position = new Vector3
				(
					TargetVelocity * Mathf.Cos(r),
					TargetVelocity * Mathf.Sin(r),
					0
				);

			spriteWhenDragging.transform.eulerAngles = new Vector3(0, 0, targetRotation);
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

		public void DestroySelf()
		{
			Destroy(gameObject);
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Shell"))
			{
				Destroy(other.gameObject);

				DestroySelf();
			}
		}

		private void setTargetRotation(PointerEventData data)
		{
			ResourceManager.Cursor.Mode = CursorStatus.Rotate;

			TargetRotation += data.delta.x;
		}

		private void setTargetVelocity(PointerEventData data)
		{
			ResourceManager.Cursor.Mode = CursorStatus.ChangeVelocity;

			TargetVelocity += data.delta.x;
		}

		private void changeRotation()
		{
			float minAngle = angularAcceleration * 
				Mathf.Pow(rb2D.angularVelocity / angularAcceleration, 2) / 2;

			float currentAngle = transform.eulerAngles.z;
			currentAngle = currentAngle > 180 ? currentAngle - 360 : currentAngle;

			float diffInAngle = TargetRotation - currentAngle;

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