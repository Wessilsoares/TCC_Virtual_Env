    //////////////////////////////////////////////////////////////////
   //  Script que implementa o comportamento do Alimentador        //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeder : MonoBehaviour
{
    public int coil;
    public float rate;
    public bool ligado;
    private GameObject objeto;

    // Envia a mensagem de preencher para o recipiente que está enteragindo - a cada frame
    void Update()
    {
       bool ligado = FactoryManager.instance.ChecaCoil(coil);
        if (objeto != null)
        {
            if (ligado == true)
            {
                objeto.gameObject.SendMessage("Fill", rate);
            }
            else
            {
                objeto.gameObject.SendMessage("NoFill");
            }
        }
        this.GetComponentInChildren<Particle>().setEmitter(ligado);
    }
        
    // Captura o recipiente que entrou em contato com o colisor
    void OnTriggerEnter(Collider co)
    {      
        objeto = co.gameObject;
    }

    //Finaliza a interação com o recipiente
    void OnTriggerExit(Collider co)
    {
        objeto.gameObject.SendMessage("FillNo");
        objeto = null;        
    }
}
