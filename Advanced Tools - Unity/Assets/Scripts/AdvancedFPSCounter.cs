using UnityEngine;

public class AdvancedFPSCounter : MonoBehaviour
{
    public float _averageFPS => _totalFrames / _timePassed;
    public float _minFPS { get; private set; }
    public float _maxFPS { get; private set; }

    
    private int _totalFrames;
    private float _timePassed;

    private void Update()
    {
        _totalFrames++;
        _timePassed += Time.deltaTime;
        
        float fpsThisFrame = 1 / Time.deltaTime;

        _minFPS = fpsThisFrame < _minFPS ? fpsThisFrame : _minFPS;
        _maxFPS = fpsThisFrame > _maxFPS ? fpsThisFrame : _maxFPS;
    }
}
