using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
	[SerializeField]
	private GameObject player;
	private NewPlayerController playerController;
	
	private RotatorToCursor rotator;
	private bool isTowerTaken;
	private bool inTrigger;
	public GameObject RideButton;
	public GameObject ShootButton;

	private Shooter shooter;

	[Range(0, 100)]
	public int radius;

	[SerializeField]
	private int damage;

	//[SerializeField]
	//private Texture2D cursorArrow;

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
		
		shooter = GetComponent<Shooter>();
		shooter.Damage = damage;
		playerController = player.GetComponent<NewPlayerController>();
	}

	void Update()
	{
        //if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        //{
        //	if (isTowerTaken)
        //	{
        //		isTowerTaken = false;
        //		playerController.Enable();
        //		_camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = minDistanse;

        //		seatingSound.Play();
        //		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //		shooter.enabled = false;

        //	}
        //	else
        //	{
        //		isTowerTaken = true;
        //		playerController.Disable();
        //		_camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = maxDistanse;

        //		seatingSound.Play();
        //		Cursor.SetCursor(cursorArrow, new Vector2(16, 16), CursorMode.ForceSoftware);
        //		shooter.enabled = true;

        //	}
        //}


	}

	public void RideTower()
    {
		Debug.Log("Button pressed");
		if (inTrigger)
		{
			if (isTowerTaken)
			{
				isTowerTaken = false;				
				_camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = minDistanse;
				seatingSound.Play();
				//Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
				shooter.enabled = false;
				playerController.Enable();
				ShootButton.SetActive(false);
			}
			else
			{
				isTowerTaken = true;				
				_camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = maxDistanse;
				seatingSound.Play();
				//Cursor.SetCursor(cursorArrow, new Vector2(16, 16), CursorMode.ForceSoftware);
				shooter.enabled = true;
				playerController.Disable();
				ShootButton.SetActive(true);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			inTrigger = true;
			RideButton.SetActive(true);
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
			RideButton.SetActive(false);
		}
	}

	private void ControlCursor()
	{
		////Get the Screen positions of the object
		//Vector2 towerPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);

		////Get the Screen position of the mouse
		//Vector2 cursorPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		//var playerToCursor = cursorPos - towerPos;

		//var dir = playerToCursor.normalized;

		//var cursorVector = dir * radius;

		//var finalPos = towerPos + cursorVector;

		////Input.mousePosition = finalPos;
	}
}
