using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdaptation : MonoBehaviour
{
    [Header("Screen.width/Screen.height*2*orthographicSize")]
    [Header("游戏的有效内容宽度")]
    public float vaildWidth;

    private void Awake()
    {
        Adaptation();
    }

    /// <summary>
    /// 适配(比开发时使用的宽度宽时不做处理)
    /// </summary>
    private void Adaptation()
    {
        float aspectRatio = Screen.width * 1f / Screen.height;
        float orthographicSize = GetComponent<Camera>().orthographicSize;
        float cameraWidth = orthographicSize * 2 * aspectRatio;
        if (cameraWidth < vaildWidth)
        {
            orthographicSize = vaildWidth / aspectRatio / 2;
            GetComponent<Camera>().orthographicSize = orthographicSize;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
