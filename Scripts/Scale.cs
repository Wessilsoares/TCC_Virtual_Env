using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public int reg;
    bool pesando = false;
    private GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pesando == true) {
            FactoryManager.instance.SetInputReg(reg, (int)(objeto.gameObject.GetComponent<Rigidbody>().mass * 100));
        }  else
            FactoryManager.instance.SetInputReg(reg, 0);
    }

    void OnTriggerEnter(Collider co)
    {
        objeto = co.gameObject;
        pesando = true;
	}

    
    void OnTriggerExit(Collider co)
    {
        pesando = false;
    }
}
