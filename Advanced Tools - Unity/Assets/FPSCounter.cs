using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text _txt;
    
    private float _totalDuration = 0;
    private int _frames = 0;

    // Update is called once per frame
    void Update()
    {
        _totalDuration += Time.deltaTime;
        _frames++;

        _txt.text = (_frames / _totalDuration).ToString();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _totalDuration = 0;
            _frames = 0;
        }
    }
}
