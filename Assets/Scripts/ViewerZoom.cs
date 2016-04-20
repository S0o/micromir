using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewerZoom : MonoBehaviour {

    public ScrollRect scrollRect;
    public GameObject scrollPanel;
    public float maxScale;
    public float minScale;
    // Use this for initialization
    void Start () {
	
	}
    private void Zoom(float direction, bool pinching)
    {
        if (direction > 0)
        {
            if (scrollPanel.transform.localScale.x < maxScale)
            {
                scrollPanel.transform.localScale += Vector3.one * 0.1f * 1 * (pinching ? 0.3f : 1);
            }
            else
            {
                scrollPanel.transform.localScale = Vector3.one * maxScale;
            }
        }
        else if (direction < 0)
        {
            if (scrollPanel.transform.localScale.x > minScale)
            {
                scrollPanel.transform.localScale += Vector3.one * 0.1f * -1 * (pinching ? 0.3f : 1);
            }
            else
            {
                scrollPanel.transform.localScale = Vector3.one * minScale;
            }
        }
    }

    private void CheckPinch()
    {
        if (Input.touchCount == 2)
        {
            Touch tOne = Input.GetTouch(0);
            Touch tTwo = Input.GetTouch(1);

            Vector2 tOnePrevPos = tOne.position - tOne.deltaPosition;
            Vector2 tTwoPrevPos = tTwo.position - tTwo.deltaPosition;

            float movementThreshold = 1f;

            if (tOne.deltaPosition.magnitude > movementThreshold && tTwo.deltaPosition.magnitude > movementThreshold)
            {
                float prevDist = (tOnePrevPos - tTwoPrevPos).magnitude;
                float currDist = (tOne.position - tTwo.position).magnitude;

                float change = currDist - prevDist;
                Zoom(change, true);
            }
            scrollRect.StopMovement();
        }
    }
    // Update is called once per frame
    void Update () {
        CheckPinch();
    }
}
