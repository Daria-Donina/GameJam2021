using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float T;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        T = Mathf.Sin(Time.time * 2f) * 0.5f;
        transform.Rotate(new Vector3(0, 1, 0), T);
    }
}
