using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //Faz a rotação da câmera
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
     {
         this.gameObject.transform.Rotate(0.0f, speed/20, 0.0f, Space.World);
     } 
    else{
        if(Input.GetKey(KeyCode.RightArrow))
     {
          this.gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
     }
    }

      if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
     {
         this.gameObject.transform.Rotate(0.0f, -speed/20, 0.0f, Space.World);
     } 
    else{
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         this.gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
     }
    }
    
    //Faz a translação da camera
    if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
     {
         Camera.main.fieldOfView = Camera.main.fieldOfView + 2 * speed * Time.deltaTime;
     } 
    else{
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    } 
     
     if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
     {
         Camera.main.fieldOfView = Camera.main.fieldOfView - 2 * speed * Time.deltaTime;
     }
        else{
            if(Input.GetKey(KeyCode.UpArrow))
            {
                this.gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }
    }
}
