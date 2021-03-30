﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FPS 显示于OnGUI 
/// </summary>
public class FPSOnGUI : MonoBehaviour
{

    float updateInterval = 1.0f;   //当前时间间隔
    private float accumulated = 0.0f;  //在此期间累积 
    private float frames = 0;    //在间隔内绘制的帧 
    private float timeRemaining;   //当前间隔的剩余时间
    private float fps = 15.0f;    //当前帧 Current FPS
    private float lastSample;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject); //不销毁此游戏对象，在哪个场景都可以显示，，不需要则注释
        timeRemaining = updateInterval;
        lastSample = Time.realtimeSinceStartup; //实时自启动
    }

    void Update()
    {
        ++frames;
        float newSample = Time.realtimeSinceStartup;
        float deltaTime = newSample - lastSample;
        lastSample = newSample;
        timeRemaining -= deltaTime;
        accumulated += 1.0f / deltaTime;

        if (timeRemaining <= 0.0f)
        {
            fps = accumulated / frames;
            timeRemaining = updateInterval;
            accumulated = 0.0f;
            frames = 0;
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle
        {
            border = new RectOffset(10, 10, 10, 10),
            fontSize = 50,
            fontStyle = FontStyle.BoldAndItalic,
        };
        //自定义宽度 ，高度大小 颜色，style
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 100, 200, 200), "<color=#000000><size=30>" + "FPS:" + fps.ToString("f2") + "</size></color>", style);
    }
}