using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[Serializable]
public class ButtonEvent : UnityEvent<PlayerControl.Direction> { }


public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameObject player;
	public PlayerControl.Direction direction;
	public ButtonEvent move, stopMove;

	void Start()
	{
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2f, Camera.main.WorldToScreenPoint(player.transform.position - player.transform.lossyScale).y);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		move.Invoke(direction);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		stopMove.Invoke(direction);
	}
}
