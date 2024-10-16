using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class AnnoyingObjectDeactivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.childCount > 0)
            other.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.childCount > 0)
            other.transform.GetChild(0).gameObject.SetActive(true);
    }
}
