using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetecter : MonoBehaviour
{
    [SerializeField, Range(0, 0.5f)]
    private float detectionDelay = 0.05f;
    [SerializeField]
    private float detectionDistance = 0.2f;
    [SerializeField]
    private LayerMask detectionLayers;

    public List<RaycastHit> detectedColliderHits {get; private set;}

    private float currentTime = 0;


    private void Start()
    {
        detectedColliderHits = PreformDetection(transform.position, detectionDistance, detectionLayers);
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime > detectionDelay)
        {
            currentTime = 0;
            detectedColliderHits = PreformDetection(transform.position, detectionDistance, detectionLayers);
        }
    }


    private List<RaycastHit> PreformDetection(Vector3 position, float distance, LayerMask mask)
    {
        List<RaycastHit> detectedHits = new();

        List<Vector3> directions = new() {transform.forward, transform.right, -transform.right};

        RaycastHit hit;
        foreach (Vector3 direction in directions)
        {
            if (Physics.Raycast(position, direction, out hit, distance, mask))
            {
                detectedHits.Add(hit);
            }
        }
        return detectedHits;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false)
        {
            return;
        }
        Color color = Color.green;
        color.a = 0.5f;

        if (detectedColliderHits.Count > 0)
        {
            color = Color.red;
            color.a = 0.5f;
        }

        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);

        List<Vector3> directions = new() {transform.forward, transform.right, -transform.right};
        Gizmos.color = Color.magenta;
        foreach (Vector3 direction in directions)
        {
            Gizmos.DrawRay(transform.position, direction);
        }
    }

}
