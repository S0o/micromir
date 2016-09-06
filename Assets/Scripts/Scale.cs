using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scale : MonoBehaviour {

    public float scale;
    public float um500=311.5f;
    public ViewerZoom vieverScript;
    public float units;
    public string nano= "nm";
    public string micro= "μm";
    public Text unitsNumb;
    public Text unitsText;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scale = vieverScript.scale;
        if (scale <=2)
        {
            units = um500;
            unitsNumb.text = "500";
            unitsText.text = micro;
        }
        else
         if (scale<=4)
         {
             units = 2*um500/5;
             unitsNumb.text = "200";
             unitsText.text = micro;
        }
        else
         if (scale <= 8)
        {
            units = um500/5;
            unitsNumb.text = "100";
            unitsText.text = micro;
        }
        else
         if (scale <= 16)
        {
            units = um500/10;
            unitsNumb.text = "50";
            unitsText.text = micro;
        }
       
       
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(scale*units,12f);
    }
}
