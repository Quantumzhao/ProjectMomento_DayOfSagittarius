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
		private SpriteRenderer spriteWhenDragging;

		private float angularAcceleration = 30;
		private float accelerarion = 30;

		public Vector3 TargetRotation;
		public bool IsRotating;

		public float targetVelocity;
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
								.gameObject
								.GetComponent<SpriteRenderer>();

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
			#region Set cursor appearance to undetermined
			if (gameObject == ResourceManager.SelectedGameObject)
			{
				Cursor.SetCursor(
					Resources.Load<Texture2D>("Change"),
					new Vector2(0, 0),
					CursorMode.ForceSoftware
				);

				cursorStatus = CursorStatus.Undetermined;
			}
			#endregion
		}

		public void OnPointerLeave(BaseEventData eventData)
		{
			#region Set cursor appearance to normal
			if (gameObject == ResourceManager.SelectedGameObject)
			{
				Cursor.SetCursor(
					Resources.Load<Texture2D>("Normal"),
					new Vector2(0, 0),
					CursorMode.ForceSoftware
				);

				cursorStatus = CursorStatus.Normal;
			}
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
			#region Revert all changes
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

			switch (((PointerEventData)eventData).button)
			{
				case PointerEventData.InputButton.Left:
					rotationHelper.OnDrag(eventData);
					break;

				case PointerEventData.InputButton.Right:
					velocityHelper.OnDrag(eventData);
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