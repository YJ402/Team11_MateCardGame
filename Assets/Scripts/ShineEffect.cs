using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShineEffect : MonoBehaviour
{
    private Material material;

    private void Awake()
    {
        material = GetComponent<Image>().material;
    }

    public void OnShine()
    {
        material.SetFloat("_ShineLocation", 0);
        StartCoroutine(Shine());
    }

    IEnumerator Shine()
    {
        while (true)
        {
            float value = material.GetFloat("_ShineLocation");
            if (value >= 1) break;
            material.SetFloat("_ShineLocation", value + 0.01f);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
