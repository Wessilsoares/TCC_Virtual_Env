    //////////////////////////////////////////////////////////////////
   //       Script que implementa o controlador de comunicação     //
  //                                                              //
 //    Autor: Wesley Silva Soares - 2021                         //
//////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyModbus;

public class FactoryManager : MonoBehaviour
{
	public float contador = 0, intervalo = 1;
	public int cor = 1, spawnner=1;
	public bool motor = false;
	protected static FactoryManager _instance;
     
	private EasyModbus.ModbusServer modbusServer = new EasyModbus.ModbusServer();
	
	//Faz a "auto instanciacao" do controlador na primeita vez que ele é chamado por outro objeto
	public static FactoryManager instance
	{
		get
		{
			_instance = FactoryManager.FindObjectOfType<FactoryManager>();
			if (_instance == null)
			{

				GameObject go = new GameObject("FactoryManager");
				_instance = go.AddComponent<FactoryManager>();
			}
			return _instance;
		}
	}
	
	// Faz a configuracao e inicialização do servidor modbus 
    void Start()
    {
		modbusServer.Port = 503;
		modbusServer.UnitIdentifier = 1;

        //inicializa o servidor modbus 
		modbusServer.Listen();
    }
	
	//Retorna o estado de uma coil
	public bool ChecaCoil(int coil)
	{
		return modbusServer.coils[coil];
	}

	//Altera o valor de uma coil
	public void SetCoil(int coil, bool estado)
	{
		modbusServer.coils[coil] = estado;
	}

	//Inverte o valor de uma coil
	public void FlipCoil(int coil)
	{
		modbusServer.coils[coil] = !modbusServer.coils[coil];
	}

	//Define o valor de uma Entrada digital
	public void SetReg(int sensor, bool estado)
	{
		modbusServer.discreteInputs[sensor] = estado; 
	}

	//Inverte o valor de uma entrada digital
	public void FlipInput(int sensor)
	{
		modbusServer.discreteInputs[sensor] = !modbusServer.discreteInputs[sensor]; 
	}

	//Interrompe o servidor modbus
	public void stopConnection(){
		modbusServer.StopListening();
	}

	//Retorna o valor de um registrador de entrada
	public int LeInputReg(int reg)
	{
		return modbusServer.inputRegisters[reg];
	}

	//Define o valor de um registrador de entrada
	public void SetInputReg(int reg, int value)
	{
		modbusServer.inputRegisters[reg] = (short)value;
	}

	//Define o valor de um registrador de saída
	public int LeHoldingReg(int reg)
	{
		return modbusServer.holdingRegisters[reg];
	}

}

