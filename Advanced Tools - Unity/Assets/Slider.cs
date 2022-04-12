using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    private UnityEngine.UI.Slider _slider;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();
    }

    public void OnValueChanged()
    {
        _slider.value = Mathf.CeilToInt(_slider.value / 100) * 100;
    }

    public void SetText()
    {
        _text.text = _slider.value.ToString();
    }
}