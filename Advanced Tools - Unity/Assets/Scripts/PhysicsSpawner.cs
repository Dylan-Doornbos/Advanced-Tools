using System;
using UnityEngine;

public class PhysicsSpawner : MonoBehaviour
{
    [SerializeField] private int _amountToSpawn;
    [SerializeField] private Rigidbody _prefab;

    [SerializeField] private customSlider customSlider;

    private Rigidbody[] _cachedRbRigidbodies;

    private bool _enablePhysics;
    private bool _enableContinuous;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clear();
            Spawn();
        }
    }

    public void SetAmountToSpawn(Single amount)
    {
        _amountToSpawn = (int)amount;
    }

    public void SetPhysics(bool isEnabled)
    {
        _enablePhysics = isEnabled;
        
        if(_cachedRbRigidbodies == null || _cachedRbRigidbodies.Length == 0) return;

        foreach (Rigidbody rb in _cachedRbRigidbodies)
        {
            rb.isKinematic = !isEnabled;
        }
    }

    public void SetContinuous(bool isContinuous)
    {
        _enableContinuous = isContinuous;

        if (_cachedRbRigidbodies == null || _cachedRbRigidbodies.Length == 0) return;

        foreach (Rigidbody rb in _cachedRbRigidbodies)
        {
            rb.collisionDetectionMode =
                _enableContinuous ? CollisionDetectionMode.Continuous : CollisionDetectionMode.Discrete;
        }
    }

    private void clear()
    {
        _cachedRbRigidbodies = null;
        
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    public void Spawn()
    {
        clear();
        _amountToSpawn = customSlider.GetValue();
        _cachedRbRigidbodies = new Rigidbody[_amountToSpawn];
        
        int totalPerLevel = 100;
        int columns = 10;
        
        for (int i = 0; i < _amountToSpawn; i++)
        {
            float x = (i % totalPerLevel) % columns + 0.5f;
            float y = i / totalPerLevel + 0.5f;
            float z = (i % totalPerLevel) / columns + 0.5f;

            Rigidbody rb = Instantiate(_prefab, transform.position + new Vector3(x, y, -z), Quaternion.identity, transform);

            if (rb == null) return;
            
            _cachedRbRigidbodies[i] = rb;
            rb.isKinematic = !_enablePhysics;
            rb.collisionDetectionMode =
                _enableContinuous ? CollisionDetectionMode.Continuous : CollisionDetectionMode.Discrete;
        }
    }
}
