using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    Color corOrig;
    // Start is called before the first frame update
    public int numero,senstype;
    void Start()
    {
        corOrig = this.gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider co)
	{
        if(senstype == 0 || checatag(co.gameObject.tag) == true)
            {
                FactoryManager.instance.SetReg(numero,true);
                this.gameObject.GetComponent<Renderer>().material.color = new Color(12, 14, 255);
            }
	}

	void OnTriggerExit(Collider co)
	{
        FactoryManager.instance.SetReg(numero,false);
        this.gameObject.GetComponent<Renderer>().material.color = corOrig;
	}

    bool checatag(string tag)
    {
        int tipo = 999;
        switch(tag)
        {
            case "laranja":
                tipo = 1;
                break;
            case "verde":
                tipo = 2;
                break;
            case "cinza":
                tipo = 3;
                break;
        }
        if(tipo == this.senstype)
        {
            return true;
        }
        return false;
    }
}
