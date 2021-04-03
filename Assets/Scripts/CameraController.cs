using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraPosition;
    }
}
