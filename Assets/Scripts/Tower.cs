using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField]
	private GameObject player;
	private RotatorToCursor rotator;
	private bool isTowerTaken;
	private bool inTrigger;
	private PlayerController playerController;

	[SerializeField]
	private Texture2D cursorArrow;

	void Start()
	{
		rotator = new RotatorToCursor(gameObject);
		playerController = player.GetComponent<PlayerController>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && inTrigger)
		{
			if (isTowerTaken)
			{
				isTowerTaken = false;
				playerController.Enable();

				//Cursor.SetCursor()
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
			else
			{
				isTowerTaken = true;
				playerController.Disable();

				Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			inTrigger = true;
		}

		if (isTowerTaken)
		{
			rotator.Rotate();
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			inTrigger = false;
			isTowerTaken = false;
		}
	}
}
