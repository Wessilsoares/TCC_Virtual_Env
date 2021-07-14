using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdTextoUI : MonoBehaviour
{
    public int addr;
    public bool IoDigital;
    string baseText;
    // Start is called before the first frame update
    void Start()
    {
        baseText = this.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (IoDigital == true)
        {
            if (FactoryManager.instance.ChecaCoil(addr) == true)
            {
                this.GetComponent<Text>().text = baseText + " ON";
                this.GetComponent<Text>().color = Color.green;
            }
            else
            {
                this.GetComponent<Text>().text = baseText + " OFF";
                this.GetComponent<Text>().color = Color.red;
            }
        }
        else
        {
            this.GetComponent<Text>().text = baseText + (float)FactoryManager.instance.LeInputReg(addr)/100;
        }
    }

    
}
