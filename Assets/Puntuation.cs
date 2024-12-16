using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuation : MonoBehaviour
{
    float _puntuation=0;

    public TMP_Text puntuationText;

    void Update()
    {
    }

    public void IncreasePuntuation(float x)
    {
        _puntuation += x;
        puntuationText.text = _puntuation.ToString();

    }

}
