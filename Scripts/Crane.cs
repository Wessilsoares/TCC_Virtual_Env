    //////////////////////////////////////////////////////////////////
   // Script que implementa o comportamento do Manipulador         //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crane : MonoBehaviour
{

    public bool grab = false,manual = false;
    private GameObject box,junta;
    public float setposZ=0,setposY=0,setangle=0, speed = 0.05f;
    public int coilZ,coilY,coilangle,regZ,regTheta,grabCoil;
    Behaviour halo;
    
    void Start()
    {
        junta =  this.gameObject.transform.Find("JuntaTheta").gameObject;
        halo = (Behaviour)junta.gameObject.GetComponent("Halo");
    }

    // A cada frame é feita a atualização de cada parâmetro do manipulador
    void Update()
    {
        getgrab();
        walk_Z();
        walk_Y();
        walk_theta();
    }
    
    //verifica se a garra está acionada e captura a caixa que está no volume de alcance da garra
    void getgrab()
    { 
        if(!manual)
        {
            grab = FactoryManager.instance.ChecaCoil(grabCoil);
        }
        // captura a caixa que está no volume de alcance e sinaliza que ela está sendo manipulada
        if (box != null)
        {
            if(grab)
            {
                box.gameObject.GetComponent<ObjEsteira>().naCrane = true; 
            } else
            {
                box.gameObject.GetComponent<ObjEsteira>().naCrane = false;
            }
        }
    }

  //Define a caixa que está na area de alcance da garra 
   void OnTriggerEnter(Collider co){
       GameObject braco = junta.gameObject.transform.Find("Braco").gameObject;
       GameObject axis = braco.gameObject.transform.Find("Axis2").gameObject;
       co.GetComponent<ObjEsteira>().crane = axis.gameObject.transform.Find("Garra").gameObject;
       box = co.gameObject;
   }

    //Faz o posicionamento da junta Theta
   void walk_theta(){
       float k, pos;
       if(manual)
       {
           pos = setangle;
       }else
       {
           pos = (float)FactoryManager.instance.LeHoldingReg(coilangle)/100;
           setangle = pos; 
       }
       // A velocidade do eixo é inversamente proporcional à diferenca entre a posical atual e o setpoint
          k = speed*(pos - junta.gameObject.transform.localEulerAngles.y);
        // Atualiza o valor do angulo local da junta theta
          junta.gameObject.transform.localEulerAngles = new Vector3(0,k,0) + junta.gameObject.transform.localEulerAngles;
           if(Math.Abs(pos - junta.gameObject.transform.localEulerAngles.y) < 0.001)
           {
               junta.gameObject.transform.localEulerAngles = new Vector3(junta.gameObject.transform.localEulerAngles.x, pos, junta.gameObject.transform.localEulerAngles.z); 
           } 
        // Atualiza o valor do registrador de feedback do angulo theta
             FactoryManager.instance.SetInputReg(regTheta, (int)(junta.gameObject.transform.localEulerAngles.y*100));
   }   
    
    //Faz o posicionamento do eixo Z
   void walk_Z(){
       float k, pos;
       if(manual)
       {
           pos = setposZ;
       }else
       {
           pos = (float)FactoryManager.instance.LeHoldingReg(coilZ)/100;
           setposZ = pos;
       }
       // limita a posição maxima e minima do eixo
       // caso o limite seja atingido, aciona a luz de alerta
        halo.enabled = false;
       if(pos > 6) 
       {
           pos = 6;
           halo.enabled = true;
       }
       if(pos < 3)
       {
           halo.enabled = true;
           pos = 3;
       }
         // A velocidade do eixo é inversamente proporcional à diferenca entre a posical atual e o setpoint
          k = speed*(pos - junta.gameObject.transform.localPosition.y);
           // Atualiza o valor do angulo local do eixo Z
          junta.gameObject.transform.localPosition = new Vector3(0,k,0) + junta.gameObject.transform.localPosition;
           if(Math.Abs(pos - junta.gameObject.transform.localPosition.y) < 0.00001)
           {
               junta.gameObject.transform.localPosition = new Vector3(junta.gameObject.transform.localPosition.x, pos, junta.gameObject.transform.localPosition.z); 
           } 
        // Atualiza o valor do registrador de feedback do eixo Z
          FactoryManager.instance.SetInputReg(regZ, (int)(junta.gameObject.transform.localPosition.y*100));
   }   

   //Faz o posicionamento do eixo Y
   void walk_Y(){
       GameObject braco = junta.gameObject.transform.Find("Braco").gameObject;
       GameObject axis = braco.gameObject.transform.Find("Axis2").gameObject;
       float k, pos;
       if(manual)
       {
           pos = setposY;
       }else
       {
           pos = (float)FactoryManager.instance.LeHoldingReg(coilY)/100;
           setposY = pos;
       }
       // limita a posição maxima e minima do eixo
       // caso o limite seja atingido, aciona a luz de alerta
        halo.enabled = false;
       if(pos > 6) 
       {
           pos = 6;
           halo.enabled = true;
       }
       if(pos < 0)
       {
           halo.enabled = true;
           pos = 0;
       }
       // A velocidade do eixo é inversamente proporcional à diferenca entre a posical atual e o setpoint
          k = speed*(pos - axis.gameObject.transform.localPosition.z);
        // Atualiza o valor do angulo local do eixo Y
          axis.gameObject.transform.localPosition = new Vector3(0,0,k) + axis.gameObject.transform.localPosition;
           if(Math.Abs(pos - axis.gameObject.transform.localPosition.z) < 0.00001)
           {
               axis.gameObject.transform.localPosition = new Vector3(axis.gameObject.transform.localPosition.x, axis.gameObject.transform.localPosition.y, pos); 
           } 
        // Atualiza o valor do registrador de feedback do eixo Z
          FactoryManager.instance.SetInputReg(regZ, (int)(axis.gameObject.transform.localPosition.z*100));
   }   
}
