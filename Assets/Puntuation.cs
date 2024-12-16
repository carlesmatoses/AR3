using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuation : MonoBehaviour
{
    float _puntuation=0;

    public void IncreasePuntuation(float x)
    {
        _puntuation += x;
    }

}
