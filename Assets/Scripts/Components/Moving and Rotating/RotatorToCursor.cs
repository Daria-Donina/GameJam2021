using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RotatorToCursor
{
    private Vector3 rotation;
    private GameObject gameObject;

    public RotatorToCursor(GameObject gameObject)
	{
        rotation = Vector3.zero;
        this.gameObject = gameObject;
    }

    public void Rotate()
	{
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(gameObject.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        rotation.z = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        gameObject.transform.rotation = Quaternion.Euler(rotation);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
