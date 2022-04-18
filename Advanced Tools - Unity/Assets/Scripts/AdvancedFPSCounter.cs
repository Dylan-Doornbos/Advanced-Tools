
using UnityEngine;
using UnityEngine.UI;

public class AdvancedFPSCounter : MonoBehaviour
{
    [SerializeField] private float _sampleDuration = 1;
    [SerializeField] private Text _fpsText;

    private float _sinceLastLog = 0;
    private int _frames = 0;
    
    private void Update()
    {
        _sinceLastLog += Time.deltaTime;
        _frames++;

        if (_sinceLastLog >= _sampleDuration)
        {
            log((int)(_frames / _sinceLastLog));
            
            _sinceLastLog = 0;
            _frames = 0;
        }
    }

    private void log(int fps)
    {
        _fpsText.text += $"{fps}\n";
    }
    
    public void Reset()
    {
        _sinceLastLog = 0;
        _frames = 0;
        _fpsText.text = "";
    }
}