using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customSlider : MonoBehaviour
{
    private UnityEngine.UI.Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private int _increments;

    public int GetValue()
    {
        return Mathf.CeilToInt(_slider.value / _increments) * _increments;
    }

    private void Awake()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();
    }

    public void OnValueChanged()
    {
        _slider.value = Mathf.CeilToInt(_slider.value / _increments) * _increments;
    }

    public void SetText()
    {
        _text.text = _slider.value.ToString();
    }
}