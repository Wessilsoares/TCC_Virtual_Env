    //////////////////////////////////////////////////////////////////
   //       Script que implementa o comportamento da Esteira       //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    public int coil = 999;
    public bool ligado;
    public bool isRampa = false; 
    
    // Update is called once per frame
    void Update()
    {
        //Verifica se é uma rampa, caso sim, mantém ativado
        if(isRampa){ 
            ligado = true;
        }
        else
            ligado = FactoryManager.instance.ChecaCoil(coil);
    }
	
    //Define que a caixa faz parte da esteira e define se está se movendo
	void OnCollisionEnter(Collision co)
	{
        //define o estado do estado que está na esteira
        co.gameObject.GetComponent<ObjEsteira>().EstadoEsteira(ligado);
        
        //mantém o objeto "acordado"
        co.gameObject.GetComponent<Rigidbody>().sleepThreshold = 0f; 
        
        //Define o ponto para onde a caida deve se mover
        co.gameObject.GetComponent<ObjEsteira>().target = this.gameObject.transform.Find("target").gameObject.transform.position;
        
	}

    private IEnumerator OnCollisionStay(Collision co){
        
        //define o estado do estado que está na esteira
        co.gameObject.GetComponent<ObjEsteira>().EstadoEsteira(ligado);

        //Define o ponto para onde a caida deve se mover
        co.gameObject.GetComponent<ObjEsteira>().target = this.gameObject.transform.Find("target").gameObject.transform.position;
       
        yield return null;
    }
   
}
