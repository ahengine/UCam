using UnityEngine;

namespace UCamSystem.Modules
{
    [RequireComponent(typeof(UCam))]
    public class CameraDragScreenLimiter : MonoBehaviour
    {
        private UCam ucam;

        private void Awake() =>
            ucam = GetComponent<UCam>();

        private void Update() {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 100 * ScreenTouchSpacePercent)
                ucam.AddLocker(this);

            if (Input.GetMouseButtonUp(0))
                ucam.RemoveLocker(this);
        }

        [SerializeField, Range(0, 100)] private float ScreenTouchSpacePercent = 80;
    }
}