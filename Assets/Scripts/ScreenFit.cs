using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFit : MonoBehaviour
{
    [SerializeField]
    Image bg;

    CanvasScaler scaler;
    RectTransform canvasRect;
    

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        scaler = this.GetComponent<CanvasScaler>();
        Debug.Log("屏幕大小: " + Screen.width + " " + Screen.height);
        Debug.Log("屏幕安全大小" + Screen.safeArea.x + " " + Screen.safeArea.y + " " + Screen.safeArea.width + " " + Screen.safeArea.height);
        RectTransform rectTransform = bg.GetComponent<RectTransform>();
        canvasRect = this.GetComponent<RectTransform>();

        if ((float)(Screen.width)/Screen.height > scaler.referenceResolution.x / scaler.referenceResolution.y)
        {
            scaler.matchWidthOrHeight = 1.0f;
            float scale = (Screen.width / scaler.referenceResolution.x) / (Screen.height / rectTransform.sizeDelta.y);
            rectTransform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            scaler.matchWidthOrHeight = 0.0f;
            float scale = (Screen.height / scaler.referenceResolution.y) / (Screen.width / rectTransform.sizeDelta.x);
            rectTransform.localScale = new Vector3(scale, scale, scale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GL.LoadOrtho();
        GL.Color(Color.red);
        GL.Begin(GL.LINES);
        GL.Vertex3(Screen.safeArea.x / Screen.width, Screen.safeArea.y / Screen.height, 0);
        GL.Vertex3(Screen.safeArea.x / Screen.width, Screen.safeArea.y / Screen.height + Screen.safeArea.height / Screen.height, 0);


        GL.Vertex3(Screen.safeArea.x / Screen.width, Screen.safeArea.y / Screen.height + Screen.safeArea.height / Screen.height, 0);
        GL.Vertex3(Screen.safeArea.x / Screen.width + Screen.safeArea.width / Screen.width, Screen.safeArea.y / Screen.height + Screen.safeArea.height / Screen.height, 0);

        GL.Vertex3(Screen.safeArea.x / Screen.width + Screen.safeArea.width / Screen.width, Screen.safeArea.y / Screen.height + Screen.safeArea.height / Screen.height, 0);
        GL.Vertex3(Screen.safeArea.x / Screen.width + Screen.safeArea.width / Screen.width, Screen.safeArea.y / Screen.height, 0);

        GL.Vertex3(Screen.safeArea.x / Screen.width + Screen.safeArea.width / Screen.width, Screen.safeArea.y / Screen.height, 0);
        GL.Vertex3(Screen.safeArea.x / Screen.width, Screen.safeArea.y / Screen.height, 0);

        GL.End();
    }
}
