using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum lighType
{
    Flicking, Normal
}
public class Blinking_light : MonoBehaviour
{
    public Transform monster;
   
    public Light2D light2D;
    public bool flick;

    public lighType light_;

    

    // Start is called before the first frame update
    void Start()
    {
        light2D = gameObject.GetComponent<Light2D>();
        if (light_ == lighType.Flicking)
        {
            StartCoroutine(lightFlicking());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(light_ == lighType.Normal)
        {
           
        }
       
       



    }

    void lightFlick()
    {
        light2D.intensity = Random.Range(0.0f, 1.0f);
    }
    IEnumerator lightFlickingMonster()
    {
        
            lightFlick();
            yield return new WaitForSeconds(0.2f);
        
    }

    IEnumerator lightFlicking()
    {
        while (true)
        {
            lightFlick();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
