using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyModbus;

public class ObjEsteira : MonoBehaviour
{
    public float velocidade, changeRate;
	 
	public bool naesteira = false, changeMass = false, naCrane = false;
	public GameObject crane;
	public Vector3 target; 

	// Start is called before the first frame update
    void Start()
    {	

    }

    // Update is called once per frame
    void Update()
    {
		UpdatePosition();
		UpdateMass();
    }
	
	void UpdateMass(){
		if (changeMass == true) {
			this.gameObject.GetComponent<Rigidbody>().mass += changeRate;
		}
	}

	void UpdatePosition()
	{
		float norm =1;
		if (this.gameObject.transform.parent != null){
		norm = this.gameObject.transform.parent.transform.localScale.x;}

		Vector3 pos = this.gameObject.transform.position;
		Vector3 esteira = new Vector3(velocidade/norm,0,0);
		Vector3 rampa = new Vector3(0,0,velocidade/(2*norm));

		if(naesteira == true){
		this.gameObject.transform.position =  Vector3.MoveTowards(pos, target, velocidade * Time.deltaTime);
		}

		if(naCrane == true){
			this.gameObject.GetComponent<Rigidbody>().useGravity = false;
			this.gameObject.transform.position = crane.gameObject.transform.position + new Vector3(0,-0.5f,0);
		}else {
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
		}

	}
	
	public void EstadoEsteira(bool estado)
	{
		naesteira = estado;
	}

	public void Fill(float rate) {
		changeMass = true;
		changeRate = rate;
	}

	public void NoFill()
	{
		changeMass = false;
		changeRate = 0;
	}
}
