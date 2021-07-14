using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAddr : MonoBehaviour
{
    public string addr;
    Color corOrig;
    // Start is called before the first frame update
    void Start()
    {
        corOrig = this.gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        GameObject obj = GameObject.Find("PhisAddr");
        obj.GetComponent<Text>().text = "Phis Addr: " + addr;
        this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 165, 0);
    }
    void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = corOrig;
        GameObject obj = GameObject.Find("PhisAddr");
        obj.GetComponent<Text>().text = "Phis Addr: -";
    }
}
