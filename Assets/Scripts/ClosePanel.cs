using UnityEngine;
using System.Collections;

public class ClosePanel : MonoBehaviour {

public void Close()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
