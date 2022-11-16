using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;


namespace PathCreation
{
    [System.Serializable]
    public class BezierPathSaveData
    {
        public BezierPathSaveData(BezierPath path, Vector3 centerPoint){
            this.points = path.GetPoints().ToArray();
            this.isClosed = path.IsClosed;
            this.perAnchorNormalsAngle = path.perAnchorNormalsAngle.ToArray();
            this.controlMode = path.ControlPointMode;
            this.autoControlLength = path.AutoControlLength;
            this.globalNormalsAngle = path.GlobalNormalsAngle;
            this.flipNormals = path.FlipNormals;
            this.centerPoint = centerPoint;
        }
        [SerializeField]
        public Vector3[] points;

        [SerializeField]
        public bool isClosed;
        [SerializeField]
        public float[] perAnchorNormalsAngle;

        [SerializeField]
        public BezierPath.ControlMode controlMode;
        [SerializeField]
        public float autoControlLength;
        [SerializeField]
        public float globalNormalsAngle;
        [SerializeField]
        public bool flipNormals;
        [SerializeField]
        public Vector3 centerPoint;
        
    }
    //[CreateAssetMenu()]
    public class BezierPathsSaved : ScriptableObject, ISerializationCallbackReceiver
    {

        [SerializeField]
        List<int> savedPathIds = new List<int> {};

        [SerializeField, HideInInspector]
        List<BezierPathSaveData> paths = new List<BezierPathSaveData>{};
        Dictionary<int, BezierPathSaveData> allPaths = new Dictionary<int, BezierPathSaveData>();
        public int SavePath(BezierPath path, Vector3 centerPoint, int id = -1)
        {
            if (allPaths.ContainsKey(id))
            {
                BezierPathSaveData data = new BezierPathSaveData(path, centerPoint);
                allPaths[id] = data;
            }
            else
            {
                if (id == -1)
                {
                    id = allPaths.Count;
                }
                BezierPathSaveData data = new BezierPathSaveData(path, centerPoint);
                allPaths[id] = data;
                savedPathIds.Add(id);
            }
            return id;
        }
        public bool ContainsPath(int id){
            return allPaths.ContainsKey(id);
        }

        public BezierPathSaveData GetPathById(int id){
            return allPaths[id];
        }

#if UNITY_EDITOR
        public static BezierPathsSaved Load(string path)
        {
            if(!File.Exists(path)){
                Debug.LogWarning("Could not find BezierPathsSaved asset. Will use default settings instead.");
                BezierPathsSaved data = ScriptableObject.CreateInstance<BezierPathsSaved>();
                UnityEditor.AssetDatabase.CreateAsset(data, path);
                UnityEditor.AssetDatabase.SaveAssets();
                return data;
            }else{
                return UnityEditor.AssetDatabase.LoadAssetAtPath<BezierPathsSaved>(path);
            }
        }

        public void OnBeforeSerialize()
        {
            savedPathIds.Clear();
            paths.Clear();
            foreach (var pair in allPaths)
            {
                savedPathIds.Add(pair.Key);
                paths.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            allPaths.Clear();
            for (int i = 0; i < savedPathIds.Count; ++i)
            {
                allPaths[savedPathIds[i]] = paths[i];
            }
        }
#endif
    }
}
