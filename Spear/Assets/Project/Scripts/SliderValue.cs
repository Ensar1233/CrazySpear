using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderValue : MonoBehaviour
{
    private Slider slider;
    private Throw sThrow;
    private float currentDuraiton;
    [SerializeField] private Transform player;

    public float amount = 0.01f;
    public bool increase;
    public float duration = 0.5f;


    void Start()
    {
        slider = GetComponent<Slider>();
        sThrow = player.GetComponent<Throw>();
        slider.value = 0;
        currentDuraiton = duration;
    }
    void FixedUpdate()
    {
        if (!sThrow.click)
        {
            slider.value = Mathf.Abs(Mathf.Sin(Time.time * amount) * 200);
        }
        else
        {
            if (Duration() )
            {
                sThrow.click = false;
                duration = currentDuraiton;
            }

        }
    }

    private bool Duration()
    {
        if (duration <= 0) 
        {
            return true;
        }
        else
        {
            duration -= Time.deltaTime;
            return false;
        }
    }
}
