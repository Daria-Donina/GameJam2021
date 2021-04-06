using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScaler : MonoBehaviour
{
    Vector3 minScale = new Vector3(0.3f, 0.3f, 0.3f);
    Vector3 maxScale = new Vector3(1f, 1f, 1f);
    float sin;

    // Update is called once per frame
    void Update()
    {
        sin = Mathf.Sin(Time.time);
        Vector3 newScale = Vector3.Lerp(minScale, maxScale, sin);
        gameObject.transform.localScale = newScale;
    }
}
