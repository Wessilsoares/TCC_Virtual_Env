    //////////////////////////////////////////////////////////////////
   // Script que implementa o comportamento da Caixa Tipo "Copo"   //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copo : MonoBehaviour
{
    public float rate=0, filled=0;
    public bool enchendo = false;
    Transform Filled; 

    // Start is called before the first frame update
    void Start()
    {
        filled = this.GetComponent<Rigidbody>().mass / 5;
        filler();
    }

    // Update is called once per frame
    void Update()
    {
       fill();
    }
    // Atualiza o nivel do copo 
    void fill(){
        // O nivel maximo ocorre quando a massa é 30
        filled = this.GetComponent<Rigidbody>().mass / 30;
        
        // Limita o nivel do copo
        if(filled > 0.95f) filled=0.95f;
        if(filled < 0) filled=0;
        
        // Faz a atualizaçao do nivel 
        Filled.localScale = new Vector3(Filled.localScale.x, filled, Filled.localScale.z);
    }

    //Captura as propriedades da caixa    
    void filler(){
        Transform[] filhos = this.GetComponentsInChildren<Transform>();
        foreach(Transform trans in filhos){
            if(trans.name == "Filled"){
                Filled = trans;
                break;
            }
        }
    }
}
