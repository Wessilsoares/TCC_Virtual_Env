    //////////////////////////////////////////////////////////////////
   //       Script que implementa o comportamento do Piso          //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{

    //Destroi os objetos que entram emcontato com o trigger 
	void OnTriggerEnter(Collider co)
	{
		Destroy(co.gameObject);
	}
}

