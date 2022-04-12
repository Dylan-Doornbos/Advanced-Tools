using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacer : MonoBehaviour
{
    private int objectCount = 0;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private Dropdown _dropdown;
    
    private Camera _camera;
    private float totalWidth = 0;

    private void Awake()
    {
        _camera = Camera.main;

        totalWidth = _camera.orthographicSize;
    }

    public void Generate()
    {
        clear();

        GameObject prefab = _prefabs[_dropdown.value];

        objectCount = (int)_slider.value;

        float sqrt = Mathf.Sqrt(objectCount);
        int columns = Mathf.CeilToInt(sqrt);

        float cellSize = totalWidth / columns;

        int spawnCount = 0;
        
        for (int i = 0; i < objectCount; i++)
        {
            float column = i % columns;
            float row = i / columns;
            float x = column * cellSize * 2 + cellSize;
            float y = row * cellSize * 2 + cellSize;

            GameObject obj = Instantiate(prefab, new Vector3(x, -y, 1) + transform.position, prefab.transform.rotation, transform);
            obj.transform.localScale = obj.transform.localScale * cellSize;

            spawnCount++;
        }
        
        Debug.Log($"Spawned {spawnCount} objects");
    }

    private void clear()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
