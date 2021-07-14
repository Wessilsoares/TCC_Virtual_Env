using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public bool acionado = false;
    public int coil =0;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ChecAcionamento();
    }

    void ChecAcionamento()
    {
        acionado = FactoryManager.instance.ChecaCoil(coil);
        if(acionado == true){
            this.gameObject.transform.eulerAngles = new Vector3(0,30,0);
            this.gameObject.transform.position = initPos + new Vector3(-0.025F,0F,-0.695F);}
        else{
            this.gameObject.transform.eulerAngles = new Vector3(0,90,0);
            this.gameObject.transform.position = initPos; 
        }
    }

}
