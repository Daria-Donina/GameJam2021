using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Sprite[] forms;
    public int damage;
    private void Start()
    {
        StartCoroutine("Transforming");
        Destroy(gameObject, 0.5f);        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        Monster monster = other.GetComponent<Monster>();
        if(monster!= null)
        {
            monster.TakeDamage(damage);
        }
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
