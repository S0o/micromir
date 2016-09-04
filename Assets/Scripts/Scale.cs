using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

    public float scale;
    public ViewerZoom vieverScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scale = vieverScript.scale;
        transform.localScale = new Vector3(scale, 1, 1);
    }
}
