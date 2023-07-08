using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
   

    public void Grown()
    {
        gameObject.LeanScale(Vector3.one * 5.1f, 1.75f).setEase(LeanTweenType.easeOutBack);
    }
}
