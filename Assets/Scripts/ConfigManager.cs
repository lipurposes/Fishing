using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ConfigManager
{
    private static readonly ConfigManager _instance = new ConfigManager();
    public static ConfigManager Instance { 
        get { 
            return _instance; 
        } 
    }  

    private BezierPathsSaved paths;

    private ConfigManager() {
        _LoadPathConfigs();
    }

    private void _LoadPathConfigs(){
        paths = Resources.Load<BezierPathsSaved>("Paths/BezierPathsSaved");
        Debug.Log(paths.GetPathById(1));
    }

    public BezierPathSaveData GetPathById(int id){
        return paths.GetPathById(id);
    }
}
