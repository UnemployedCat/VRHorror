using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private HeadCollisionDetecter detector;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    public float pushBackStrength = 1.0f;

    private void FixedUpdate()
    {
        if (detector.detectedColliderHits.Count <= 0)
        {
            return;
        }
        Vector3 pushBackDirection = CalculatePushBackDirection(detector.detectedColliderHits);

        Debug.DrawRay(transform.position, pushBackDirection.normalized, Color.magenta);

        characterController.Move(pushBackDirection.normalized * pushBackStrength * Time.deltaTime);
    }

    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormal = Vector3.zero;
        foreach (RaycastHit hitPoint in colliderHits)
        {
            combinedNormal += new Vector3(hitPoint.normal.x, 0, hitPoint.normal.z);
        }
        return combinedNormal;
    }
}
