using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavacolorscript : MonoBehaviour
{

    public Material LavaMat;
    public float amplitud = 3, offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(Time.time * amplitud);
        LavaMat.SetFloat("_addposicioninferior", x);
    }
}
