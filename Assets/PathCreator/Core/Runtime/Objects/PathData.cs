using System.Collections.Generic;
using UnityEngine;

namespace PathCreation {
    public class PathData : MonoBehaviour {
        static BezierPathsSaved bezierPaths;
        [SerializeField]
        public List<int> pathsIds;
        private void Awake()
        {
            bezierPaths = Resources.Load(@"Paths/BezierPathsSaved") as BezierPathsSaved;
            pathsIds = bezierPaths.savedPathIds;
        }
    }
}