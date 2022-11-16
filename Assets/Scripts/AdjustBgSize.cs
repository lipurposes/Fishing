using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustBgSize : MonoBehaviour
{
    float _width = 11.36f;
    float _height = 7.2f;
    private void Awake()
    {
        
    }
    
    private void Adjust()
    {
        Camera camera = Camera.main;
        float aspectRatio = Screen.width * 1f / Screen.height;
        float orthographicSize = camera.orthographicSize;
        float cameraWidth = orthographicSize * 2 * aspectRatio;
        if (cameraWidth > _width)
        {
            float scale = cameraWidth / _width;
            transform.localScale = new Vector3(_width * scale / 10, 1, _height * scale / 10);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Adjust();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
