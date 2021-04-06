using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Sprite[] forms;
    private void Start()
    {
        StartCoroutine("Transforming");
        Destroy(gameObject, 0.5f);
        
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //}
    public void ShootBullet()
    {
        
    }

    IEnumerator Transforming()
    {
        for (int i = 0; i < forms.Length; i++)
        {
            GetComponent<SpriteRenderer>().sprite = forms[i];
            yield return new WaitForSeconds(.02f);            
        }
        
    }

}
