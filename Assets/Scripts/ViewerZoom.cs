using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewerZoom : MonoBehaviour {

    public ScrollRect scrollRect;
    public GameObject scrollPanel;
    public float zoomSpeed=0.1f;
    public float maxScale;
    public float minScale;
    public bool zoomed;

    public Vector2 first=new Vector2(0, 0);
    public Vector2 midPoint = new Vector2(0, 0);

  
    private Vector2 screenSize;
    void Start () {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    private void Zoom(float direction, bool pinching)
    {
        scrollPanel.transform.localScale += Vector3.one * direction*zoomSpeed;
       
            if (scrollPanel.transform.localScale.x > maxScale)
              {
    
                  scrollPanel.transform.localScale = Vector3.one * maxScale;
              }
        
              if (scrollPanel.transform.localScale.x < minScale)
              {
          
                  scrollPanel.transform.localScale = Vector3.one * minScale;
              }
          
        
       
     //   if (scrollPanel.transform.localScale.x > maxScale) scrollPanel.transform.localScale = Vector3.one * maxScale;
     // if (scrollPanel.transform.localScale.x < minScale) scrollPanel.transform.localScale = Vector3.one * minScale;
    } 
    public void Return()
    {
        scrollPanel.transform.localScale = Vector3.one;
        scrollPanel.GetComponent<RectTransform>().anchoredPosition =  Vector2.zero;
        transform.parent.localScale = Vector3.one;

    }
    private void CheckPinch()
    {
       
        if (Input.touchCount == 0)
            zoomed = false;
        if (Input.touchCount == 1)
            first = Input.GetTouch(0).position;
        if (Input.touchCount == 2)
        {
            midPoint = new Vector2(((Input.GetTouch(0).position.x + Input.GetTouch(1).position.x) / 2), ((Input.GetTouch(0).position.y + Input.GetTouch(1).position.y) / 2));
           
          //  midPoint = Camera.main.ScreenToWorldPoint(midPoint);
          // midPoint.x -= Screen.width/2;
          //  midPoint.y -= Screen.height / 2;
            midPoint = Camera.main.ScreenToWorldPoint(midPoint);
            zoomed = true;
            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);

            //  scrollPanel.transform.localPosition 
            //scrollPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(midPoint.x, midPoint.y);
            Vector2 tZeroPrevPos = tZero.position - tZero.deltaPosition;
            Vector2 tOnePrevPos = tOne.position - tOne.deltaPosition;

            float movementThreshold = 0f;

            if (tZero.deltaPosition.magnitude > movementThreshold && tOne.deltaPosition.magnitude > movementThreshold)
            {
                float prevDist = (tZeroPrevPos - tOnePrevPos).magnitude;
                float currDist = (tZero.position - tOne.position).magnitude;

                float change = currDist - prevDist;
                Zoom(change, true);
            }
            
        }
        if (zoomed)
        {
            scrollRect.horizontal=false;
            scrollRect.vertical = false;
        }
        else
        {
            scrollRect.horizontal = true;
            scrollRect.vertical = true;
        }

    }
    // Update is called once per frame
    void Update () {
        //
        CheckPinch();
    }
}
