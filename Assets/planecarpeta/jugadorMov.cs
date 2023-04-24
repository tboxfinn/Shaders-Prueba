using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorMov : MonoBehaviour
{
    Rigidbody rigidbody;
     public float playerspeed=111;
      public float rotationlerpspeed=.2f;
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

      if(Input.GetKey(KeyCode.R)){
          //  attack1();
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
