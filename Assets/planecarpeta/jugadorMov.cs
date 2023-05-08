using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class jugadorMov : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float playerspeed=111;
    public float rotationlerpspeed=.2f;
    public GameObject CanvasNieve;
    public bool CanvasActivado;
    public RawImage imagen;
    public Material materialSG;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
          Vector3  move = Vector3.zero;
     if(Input.GetKey(KeyCode.A)){
        move.x = -1;
     }  
     if(Input.GetKey(KeyCode.D)){
        move.x = 1;
     }  
     if(Input.GetKey(KeyCode.S)){
        move.z = -1;
     }  
     if(Input.GetKey(KeyCode.W)){
        move.z = 1;
     }   

      if (Input.GetKeyDown(KeyCode.R))
      {
            //  attack1();
            materialSG.SetFloat("_Power", 100);
      }
      if (Input.GetKeyDown(KeyCode.T))
      {
            //  attack1();
            materialSG.SetFloat("_Power", 4000);
        }

        move.Normalize();

//MOVMIENTO
     //transform.position += move * playerspeed*Time.deltaTime;
     rigidbody.AddForce( move * playerspeed*Time.deltaTime*10);

//ROTACION PERSONAJE
     if(move != Vector3.zero){
      Quaternion rota = Quaternion.LookRotation( move, Vector3.up);
      transform.rotation = Quaternion.RotateTowards(transform.rotation, rota,rotationlerpspeed);
      }
    }
}
