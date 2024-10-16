using UnityEngine;

namespace UCamSystem
{
    [System.Serializable]
    public class TransformState
    {
        public Vector3 position;
        public Quaternion rotation;


        public void Set() =>
            Set(UCam.Instance.Ghost.transform);
        public void Set(Transform point) =>
            Set(point.position, point.rotation);
        public void Set(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }

        public void Apply() =>
            UCam.Instance.Ghost.transform.SetPositionAndRotation(position, rotation);
    }
}