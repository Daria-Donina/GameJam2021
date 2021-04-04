using Cinemachine;
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

	private Shooter shooter;

	[Range(0, 100)]
	public int radius;

	[SerializeField]
	private int damage;

	[SerializeField]
	private Texture2D cursorArrow;

	[SerializeField]
	private AudioSource seatingSound;

	[SerializeField]
	CinemachineVirtualCamera _camera;

	[SerializeField]
	private int maxDistanse;

	[SerializeField]
	private int minDistanse;


	void Start()
	{
		//Debug.Log(transform.GetChild(0).position);
		//Debug.Log(transform.position);

		rotator = new RotatorToCursor(gameObject);
		playerController = player.GetComponent<PlayerController>();
		shooter = GetComponent<Shooter>();
		shooter.Damage = damage;		
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && inTrigger)
		{
			if (isTowerTaken)
			{
				isTowerTaken = false;
				playerController.Enable();
				_camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = minDistanse;

				seatingSound.Play();
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
				shooter.enabled = false;
				
			}
			else
			{
				isTowerTaken = true;
				playerController.Disable();
				_camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = maxDistanse;

				seatingSound.Play();
				Cursor.SetCursor(cursorArrow, new Vector2(16, 16), CursorMode.ForceSoftware);
				shooter.enabled = true;
				
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
			rotator.Rotate(transform.GetChild(0).position);
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

	private void ControlCursor()
	{
		//Get the Screen positions of the object
		Vector2 towerPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);

		//Get the Screen position of the mouse
		Vector2 cursorPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		var playerToCursor = cursorPos - towerPos;

		var dir = playerToCursor.normalized;

		var cursorVector = dir * radius;

		var finalPos = towerPos + cursorVector;

		//Input.mousePosition = finalPos;
	}
}
