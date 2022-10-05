using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUIElement : MonoBehaviour
{
    public void EnableElement(GameObject element)
    {
        element.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
