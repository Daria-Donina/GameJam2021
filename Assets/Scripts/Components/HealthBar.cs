using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] 
    private Slider sliderHealthBar;
    [SerializeField] 
    private GameObject gameobject;

    private DestroyedObject destroyedObject;

    private void Start()
    {
        destroyedObject = gameobject.GetComponent<DestroyedObject>();

        sliderHealthBar.value = getCurrentHP();
        sliderHealthBar.maxValue = getCurrentMaxHP();
    }

    private void Update()
    {
        sliderHealthBar.value = getCurrentHP();
    }

    public void SetHealth(int hp)
    {
        sliderHealthBar.value = hp;
    }

    public int getCurrentHP()
    {
        return destroyedObject.Health;
    }

    public int getCurrentMaxHP()
    {
        return destroyedObject.MaxHealth;
    }
}
