using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace PathCreation {
    public class PathData : MonoBehaviour {

        public float vertexPathMaxAngleError = .3f;
        public float vertexPathMinVertexSpacing = 0.01f;

        private int _id = -1;

        BezierPath _bezierPath;
        VertexPath _vertexPath;
        
        public int Id {
            get {
                return _id;
            }
        }

        void Start()
        {
            setPath(ConfigManager.Instance.GetPathById(3), 3);
        }

        public void setPath(BezierPathSaveData data, int pathId){
            if(_id == pathId){
                return;
            }
            _bezierPath = new BezierPath(data);
            transform.position = data.centerPoint;
            _vertexPath = new VertexPath (_bezierPath, transform, vertexPathMaxAngleError, vertexPathMinVertexSpacing);
        }

        public VertexPath Path {
            get {
                return _vertexPath;
            }
        }
    }
}