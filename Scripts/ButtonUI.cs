    //////////////////////////////////////////////////////////////////
   //  Script que implementa o comportamento dos Botoes da GUI     //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    // Muda manualmente o estado da coil selecionada
      public void ManChangeState(int coil) 
    {
        FactoryManager.instance.FlipCoil(coil);
    }

    // Muda manualmente o estado da Discrete input selecionada
     public void ManFlipInput(int input) 
    {
        FactoryManager.instance.FlipInput(input);
    }

    // Carrega a Cena Selecionada
    public void StartALevel(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
