using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FPSUI : MonoBehaviour
{
    [SerializeField] private Text _fpsText;
    [SerializeField] AdvancedFPSCounter _counter;

    private void Update()
    {
        StringBuilder stringBuilder = new StringBuilder();

            //stringBuilder.AppendFormat("Min: {0}\nMax: {1}\nAverage: {2}", _counter._minFPS, _counter._maxFPS,
            //_counter._averageFPS);

        _fpsText.text = stringBuilder.ToString();
    }
}