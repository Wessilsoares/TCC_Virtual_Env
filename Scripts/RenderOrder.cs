using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    [ExecuteInEditMode]
    // Start is called before the first frame update
    public int order=0;
    void Awake()
    {
        MeshRenderer mesh;
        try{
            mesh = this.GetComponent<MeshRenderer>();
            mesh.rendererPriority = order;
        }catch{}
    }

}
