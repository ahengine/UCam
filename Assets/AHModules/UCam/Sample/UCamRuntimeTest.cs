using UnityEngine;

namespace UCamSystem.Sample {
    
    public class UCamRuntimeTest : MonoBehaviour {
        [SerializeField] private UCamPoint firstPersonPoint;
        [SerializeField] private UCamPoint orbitPoint;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                firstPersonPoint.Set();

            if (Input.GetKeyDown(KeyCode.Alpha2))
                orbitPoint.Set();
        }
    }
}