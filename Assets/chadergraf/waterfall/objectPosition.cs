using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPosition : MonoBehaviour
{
    Renderer rend;
    Vector3 lastPos;
    Vector3 lastRot;

    float rotarX, rotarZ;
    float timer = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_ObjectPosition", new Vector4(this.transform.position.x, this.transform.position.y, this.transform.position.z, this.transform.localScale.x));
        timer += Time.deltaTime;
        rotarX = this.transform.localScale.x;
        rotarZ = this.transform.localScale.z;
    }
}
