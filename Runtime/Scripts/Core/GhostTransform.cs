using UnityEngine;

namespace UCamSystem
{
    public class GhostTransform : MonoBehaviour
    {
        public static GhostTransform CreateInstance() =>
            new GameObject("UCam Target [GhostTransform]").AddComponent<GhostTransform>();

        public Transform Tr => 
            transform;

        public Transform Parent =>
            transform.parent;
       
        public void SetParent(Transform parent) {
            transform.SetParent(parent);
            if (!parent)
                return;
            transform.SetLocalPositionAndRotation(Vector3.zero,Quaternion.identity);
        }

        public void SetPositionRotation(Transform point) =>
            transform.SetPositionAndRotation(point.position, point.rotation);

        public Vector3 GetEuler(Space space = Space.World, bool ParentRoot = false) =>
            space == Space.World ? (ParentRoot?Parent:transform).eulerAngles : (ParentRoot?Parent:transform).localEulerAngles;
        public void SetEuler(Vector3 euler, Space space = Space.World, bool ParentRoot = false) 
        {
            switch(space)
            {
                case Space.World:
                    (ParentRoot?Parent:transform).eulerAngles = euler;
                    break;
                case Space.Self:
                    (ParentRoot?Parent:transform).localEulerAngles = euler;
                    break;
            }
        }

        public void SetRotation(Quaternion value, Space space = Space.World, bool ParentRoot = false)
        {
            switch(space)
            {
                case Space.World:
                    (ParentRoot?Parent:transform).rotation = value;
                    break;
                case Space.Self:
                    (ParentRoot?Parent:transform).localRotation = value;
                    break;
            }
        }

        public void SetPosition(Vector3 newPosition) =>
            transform.position = newPosition;
    }
}