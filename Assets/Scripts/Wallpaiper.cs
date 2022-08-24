using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wallpaiper : MonoBehaviour
{

    public float scroolSpeed;
    float offset;
    Material material;



    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void LateUpdate()
    {
        offset += scroolSpeed * Time.deltaTime;
        material.mainTextureOffset = new Vector2(offset, 0);
    }

   
}
