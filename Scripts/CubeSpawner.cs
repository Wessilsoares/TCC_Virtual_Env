    //////////////////////////////////////////////////////////////////
   //       Script que implementa o comportamento do Emissor       //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	public GameObject cubeType2, cubeType1,cubeType3;
	public float contador = 0, intervalo = 15;
	private bool livre = true, emitir = false;
	public int coil;

    // Update is called once per frame
    void Update()
    {
		// Caso o emissor estiver ligado, incrementa o contador
		emitir = FactoryManager.instance.ChecaCoil(coil);
		if (livre == true && emitir == true)
		{
			contador += Time.deltaTime;
		}

		//Quando o atinge o valor do intervalo, emite uma caixa nova
		if(contador > intervalo && FactoryManager.instance.spawnner == 1) 
		{
		   contador = 0;
		   spawn();
		}
	}
	
	//faz a emissao das caixas
	public void spawn()
	{
		bool done = false;
		
		//instancia um cubo de tipo aleatório
		while(!done)
		{
			int rnd = Random.Range(0,3);
			GameObject cubo;
			
			//Define a tag do tipo da caixa
			switch(rnd){
				case 0:
					cubo = cubeType1;
					cubo.tag = "laranja";
					break;
				case 1:
					cubo = cubeType2;
					cubo.tag = "verde";
					break;
				case 2:
					cubo = cubeType3;
					cubo.tag = "cinza";
					break;
				default: 
					cubo = cubeType1;
					cubo.tag = "laranja";
					break;

			}

			//Instancia a nova caixa e define uma massa inicial aleatória
			if(cubo != null)
			{
				GameObject novocubo = (GameObject)Instantiate(cubo,this.transform);	
				novocubo.GetComponent<Rigidbody>().mass = Random.Range(1,5);
				done = true;
			}	
		}
	}

	//verifica se há uma caixa na regiao de spawn e bloqueia o emissor
	void OnTriggerEnter(Collider co) 
	{
		livre = false;        
	}

	//verifica se há uma caixa na regiao de spawn e libera o emissor
	void OnTriggerExit(Collider co)
	{
		livre = true;
	}
}
