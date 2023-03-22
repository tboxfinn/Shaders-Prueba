using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pocionRotar : MonoBehaviour
{
    Renderer rend;
    Vector3 lastPos;
    Vector3 lastRot;

    float rotarX, sumarX, rotarZ, sumarZ;
    float timer = 0.01f;

    public Vector3 velocity, velocityAng;

    [SerializeField]
    private float factorAtenuante = .5f, rotationSpeed, maxRotation = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shader.SetGlobalVector("_ObjectPosition", new Vector4(this.transform.position.x, this.transform.position.y, this.transform.position.z, this.transform.localScale.x));
        timer += Time.deltaTime;

        sumarX = Mathf.Lerp(sumarX, 0, Time.deltaTime * factorAtenuante);
        sumarZ = Mathf.Lerp(sumarZ, 0, Time.deltaTime * factorAtenuante);

        rotarX = sumarX * Mathf.Sin(rotationSpeed);
        rotarZ = sumarZ * Mathf.Sin(rotationSpeed);

        rend.material.SetFloat("_rotateX", rotarX);
        rend.material.SetFloat("_RotateY", rotarZ);

        velocity = (lastPos - transform.position) / Time.deltaTime;
        velocityAng = transform.rotation.eulerAngles - lastRot;

        sumarX += Mathf.Clamp(velocity.x + velocityAng.z, -maxRotation, maxRotation);
        sumarZ += Mathf.Clamp(velocity.z + velocityAng.x, -maxRotation, maxRotation);

        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;
    }
}
