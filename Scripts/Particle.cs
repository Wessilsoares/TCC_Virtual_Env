using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
     ParticleSystem ps;
     bool ligado;
    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();    
        ligado = this.gameObject.GetComponentInParent<Feeder>( ).ligado;
    }

    // Update is called once per frame
    void Update()
    {
    } 
        public void setEmitter(bool state){
                var em = ps.emission;
                 em.enabled = state;
        }
    }
    
