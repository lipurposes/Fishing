using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]//用于MonoBehaviour或其子类，不能重复添加这个类的组件，重复添加会弹出对话框
[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private RectTransform _rect;
    private float _sizeToDesignRate;
    protected RectTransform rectTransform
    {
        get
        {
            if (_rect == null)
              _rect = GetComponent<RectTransform>();
            return _rect;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        CanvasScaler canvasScaler = rectTransform.GetComponentInParent<CanvasScaler>();
        _sizeToDesignRate = Screen.width / canvasScaler.referenceResolution.x;
        Debug.Log("设计分辨率比率是: " + _sizeToDesignRate);
        Debug.Log("anchorMin is " + rectTransform.anchorMin);
        Debug.Log("anchorMax is " + rectTransform.anchorMax);
        if(rectTransform.anchorMin == rectTransform.anchorMax)
        {
            if(rectTransform.anchorMin.x < 0.01)
            {
                Debug.Log("左边需要调整");
                AdjustLeft();
            }else if(rectTransform.anchorMax.x > 0.99){
                Debug.Log("右边需要调整");
                AdjustRightByAnchor();
            }
        }
    }

    void AdjustRightByAnchor()
    {
        float safeX = Screen.safeArea.x + Screen.safeArea.width;
        float maxX = safeX / Screen.width;
        rectTransform.anchorMin = new Vector2(maxX, rectTransform.anchorMin.y);
        rectTransform.anchorMax = rectTransform.anchorMin;
    }

    void AdjustLeftByAnchor()
    {
        float safeX = Screen.safeArea.x;
        float minX = safeX / Screen.width;
        rectTransform.anchorMin = new Vector2(minX, rectTransform.anchorMin.y);
        rectTransform.anchorMin = new Vector2(minX, rectTransform.anchorMin.y);
    }

    void AdjustRight()
    {
        float safeX = Screen.width - (Screen.safeArea.x + Screen.safeArea.width);
        float minX = safeX / _sizeToDesignRate;
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x - minX, rectTransform.localPosition.y, rectTransform.localPosition.z);
    }

    void AdjustLeft()
    {
        float safeX = Screen.safeArea.x;
        float minX = safeX / _sizeToDesignRate;
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x + minX, rectTransform.localPosition.y, rectTransform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
