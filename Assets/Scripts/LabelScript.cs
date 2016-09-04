using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LabelScript : MonoBehaviour {

    public string text;
    public Vector2 center;
    public Vector2 dest;
    public RectTransform arrow;
    public Vector2 aim;
    public float angle;
   
    void Start () {
	
	}
	
	
	void Update () {

        center = transform.position;
        aim = -center + dest;
        arrow.position = center;
        angle = Vector2.Angle(aim, Vector2.down);
        if (dest.x <= center.x)
            arrow.eulerAngles = new Vector3(0,0, -angle);
        else
            arrow.eulerAngles = new Vector3(0, 0, angle);
        arrow.sizeDelta =new Vector2(100, Vector2.Distance(dest, center));
    }
}
