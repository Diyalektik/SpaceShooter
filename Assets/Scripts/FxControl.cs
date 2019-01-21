using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControl : MonoBehaviour {

    public float hiz;
	Rigidbody fizik;
    Vector3 vec;
    void Start () {
		fizik=GetComponent<Rigidbody>();
        
        vec =new Vector3(0, 0, 1);
        fizik.velocity = vec*hiz;
    }
	
	
	
}
