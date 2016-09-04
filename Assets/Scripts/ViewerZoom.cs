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
    public float scale=1;
    public float prevScale=1;
    public Vector2 first=new Vector2(0, 0);
    public Vector2 midPoint = new Vector2(0, 0);
    
    static Vector3 prevPos = Vector3.zero;

    public Transform target;

    public Vector3 diff;
    public Vector3 pos;

    public Vector2 firstMidPoint;
    public Vector2 diffFirst;

    private Vector2 screenSize;

    void Start ()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void OnEnable()
    {
        scrollPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        scale = 1;
        scrollPanel.transform.localScale =new Vector3(1,1,1);
    }

    private void Zoom(float direction)
    {
        scrollPanel.transform.localScale += Vector3.one * direction*zoomSpeed*scale;
        scale = scrollPanel.transform.localScale.x;

            if (scale > maxScale)
              {
                scale= maxScale;
              }
        
              if (scale < minScale)
              {
            scale = minScale;
        }

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
            if (!zoomed)
                firstMidPoint = midPoint;
            zoomed = true;
            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);

            Vector2 tZeroPrevPos = tZero.position - tZero.deltaPosition;
            Vector2 tOnePrevPos = tOne.position - tOne.deltaPosition;

            float prevDist = (tZeroPrevPos - tOnePrevPos).magnitude;
            float currDist = (tZero.position - tOne.position).magnitude;
            float change = currDist - prevDist;

            Zoom(change);

           
            scaleFromPosition(scale, midPoint);

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


    private void scaleFromPosition(float scale, Vector3 fromPos)
    {
        
        Vector3 prevParentPos = transform.position;
           
        float scaleDiff = scale - prevScale;
        diff = (fromPos - prevParentPos)* scaleDiff;
        pos = new Vector3(-diff.x / scale  , -diff.y / scale  , 0);
        transform.position = new Vector3(prevParentPos.x + pos.x - firstMidPoint.x+ fromPos.x, prevParentPos.y - firstMidPoint.y + pos.y + fromPos.y, pos.z);
        firstMidPoint = fromPos;
        transform.localScale = scale * Vector2.one;
        prevPos = fromPos;
        prevScale = scale;
    }

    void Update () {
        
        CheckPinch();
    }
}
