using UnityEngine;

namespace UCamSystem
{
    public class GhostTransform : MonoBehaviour
    {
        public static GhostTransform CreateInstance() =>
            new GameObject("UCam Target [GhostTransform]").AddComponent<GhostTransform>();
       
        public void SetParent(Transform parent) {
            transform.SetParent(parent);
            if (!parent)
                return;
            transform.SetLocalPositionAndRotation(Vector3.zero,Quaternion.identity);
        }

        public void SetPositionRotation(Transform point) =>
            transform.SetPositionAndRotation(point.position, point.rotation);

        public Vector3 GetEuler(Space space = Space.World) =>
            space == Space.World ? transform.eulerAngles : transform.localEulerAngles;
        public void SetEuler(Vector3 euler, Space space = Space.World) 
        {
            switch(space)
            {
                case Space.World:
                    transform.eulerAngles = euler;
                    break;
                case Space.Self:
                    transform.localEulerAngles = euler;
                    break;
            }
        }

        public void SetRotation(Quaternion value, Space space = Space.World)
        {
            switch(space)
            {
                case Space.World:
                    transform.rotation = value;
                    break;
                case Space.Self:
                    transform.localRotation = value;
                    break;
            }
        }
    }
}