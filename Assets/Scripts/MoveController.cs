using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
	public float speed = 5f;

	public enum Direction { Left = -1, Stationary = 0, Right = 1 };

	Direction direction = Direction.Stationary;
	Vector3 leftScreenBorder, rightScreenBorder;
	bool buttonMoveLeftPressed, buttonMoveRightPressed;

	// Use this for initialization
	void Start ()
	{
		buttonMoveLeftPressed = false;
		buttonMoveRightPressed = false;

		float halfSizePlayer = this.transform.lossyScale.x / 2f;

		leftScreenBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
		leftScreenBorder.x += halfSizePlayer;
		leftScreenBorder.z = 0;

		rightScreenBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
		rightScreenBorder.x -= halfSizePlayer;
		rightScreenBorder.z = 0;
	}

	void FixedUpdate()
	{
		if (direction == Direction.Stationary) { return; }

		float newPosX = this.transform.position.x + speed * ((int)direction) * Time.deltaTime;
		this.transform.position = new Vector3(Mathf.Clamp(newPosX, leftScreenBorder.x, rightScreenBorder.x),
											  this.transform.position.y, 
											  this.transform.position.z);
	}
	
	public void Move(Direction newDirection)
	{
		switch (newDirection) {
			case Direction.Left:
				buttonMoveLeftPressed = true;
				break;
			case Direction.Right:
				buttonMoveRightPressed = true;
				break;
			default:
				break;
		}

		direction = newDirection;
	}
	

	public void StopMove(Direction dir)
	{
		direction = Direction.Stationary;

		switch (dir) {
			case Direction.Left:
				buttonMoveLeftPressed = false;
				if (buttonMoveRightPressed) {
					direction = Direction.Right;
				}
				break;
			case Direction.Right:
				buttonMoveRightPressed = false;
				if (buttonMoveLeftPressed) {
					direction = Direction.Left;
				}
				break;
			default:
				break;
		}
	}
}
