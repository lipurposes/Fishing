using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();//动画控制器
        animation.Play("idle");//上来直接播放idle动画
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 30), "行走"))
        {
            animation.Play("run");
        }
        if (GUI.Button(new Rect(100, 0, 100, 30), "停止"))
        {
            animation.Play("idle");
        }
        if (GUI.Button(new Rect(200, 0, 100, 30), "攻击"))
        {
            animation.Play("attack");
            animation.PlayQueued("idle");//播放完attack之后再播放idle
        }
    }
}
