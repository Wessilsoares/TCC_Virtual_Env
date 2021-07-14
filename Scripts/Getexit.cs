using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Getexit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {   
            FactoryManager.instance.stopConnection();
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
            
        }
    }
}
