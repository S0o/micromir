using UnityEngine;
using System.Collections;
using UnityEngine. UI;

public class ScrollContent : MonoBehaviour {
    public int contentCount;
    private Rect rectTrans; 
    // Use this for initialization
    void Start () {
        rectTrans = this.transform.GetComponent<RectTransform>().rect;
    }
	
	
	void Update () {
        rectTrans.height = 390 * contentCount % 2;
    }
}
