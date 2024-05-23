using UnityEngine;
using UnityEngine.EventSystems;

namespace UCamSystem.Modules
{
    public class CameraLockOnDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
    {

	public void OnPointerDown(PointerEventData dt)  =>
        UCam.Instance.AddLocker(this);

	public void OnPointerUp(PointerEventData dt) =>
        UCam.Instance.RemoveLocker(this);

    }
}