using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollowerTest : MonoBehaviour
    {
        public PathData pathData;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float beginTime = 0;
        float distanceTravelled;

        private int _curIndex = 0; //当前位置路径左边点index,不管是否反转

        void Start() {
            distanceTravelled += speed * beginTime;
        }

        void Update()
        {
            if (pathData != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                VertexPath.TimeOnPathData timePath = pathData.Path.CalculatePercentByLastPointIndexAndDis(_curIndex, distanceTravelled, endOfPathInstruction);
                transform.position = pathData.Path.GetPointByTimePathData(timePath);
                transform.rotation = pathData.Path.GetRotationByTimePathData(timePath, distanceTravelled, endOfPathInstruction);
                _curIndex = timePath.previousIndex;
            }
        }
    }
}