using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject it;
    bool isClick = false;
    // Start is called before the first frame update
    public void click()
    {
        if (isClick == false)
        {
            isClick = true;
            it.SetActive(true);
            Invoke("next", 2.3f);
        }
    }

    void next()
    {
        isClick = false;
        it.SetActive(false);
    }
}
