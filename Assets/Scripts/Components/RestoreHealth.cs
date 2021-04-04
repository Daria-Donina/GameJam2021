using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{
    [SerializeField]
    private DestroyedObject gameobject;
    [SerializeField]
    private KeyCode KeyCodeOfRestoreHealth = KeyCode.E;
    [SerializeField]
    [Range(0, 100)]
    private int percentageOfRestorePerClick = 10;

    private bool inTrigger;

    private void RestoreObjectHealth()
    {
        int maxPercentage = 100;
        gameobject.Health += gameobject.MaxHealth * percentageOfRestorePerClick / maxPercentage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCodeOfRestoreHealth) && inTrigger)
        {
            RestoreObjectHealth();
            Debug.Log("Storage|Press E");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inTrigger = true;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inTrigger = false;
            Debug.Log("Exit");
        }
    }
}
