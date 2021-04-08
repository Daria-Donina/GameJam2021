using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealth : MonoBehaviour
{
    [SerializeField]
    private DestroyedObject Gate;
    //[SerializeField]
    //private KeyCode KeyCodeOfRestoreHealth = KeyCode.E;
    [SerializeField]
    [Range(0, 100)]
    private int percentageOfRestorePerClick = 10;

    private bool inTrigger = false;

    public GameObject HealButton;    
    AudioSource repairSound;    
    bool restoring = false;


    private void Start()
    {
        repairSound = GetComponent<AudioSource>();
    }

    public void RestoreObjectHealth()
    {
        if (inTrigger && !restoring)
        {
            StartCoroutine("Restoring");
        }                
    }

    IEnumerator Restoring()
    {
        repairSound.Play();
        restoring = true;
        HealButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(1.7f);
        repairSound.Play();
        yield return new WaitForSeconds(1.7f);
        int maxPercentage = 100;
        Gate.Health += Gate.MaxHealth * percentageOfRestorePerClick / maxPercentage;
        restoring = false;
        HealButton.GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gate.Health > 900 || restoring)
        {
            HealButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            HealButton.GetComponent<Button>().interactable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inTrigger = true;
            Debug.Log("Enter");
            HealButton.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inTrigger = false;
            Debug.Log("Exit");
            HealButton.SetActive(false);
        }
    }
}
