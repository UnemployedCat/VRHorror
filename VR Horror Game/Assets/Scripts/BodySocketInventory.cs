using Unity.Mathematics;
using UnityEngine;

public class BodySocketInventory : MonoBehaviour
{

    public GameObject Camera;
    //public bodySocket[] bodySockets;

    private Vector3 currentCameraPosition;
    private Quaternion currentCameraRotation;

    // Update is called once per frame
    void Update()
    {
        currentCameraPosition = Camera.transform.position;
        currentCameraRotation = Camera.transform.rotation;
        /*
        foreach (bodySocket bodySocket in bodySockets)
        {
            UpdateBodySocketHeight(bodySocket);
        }
        */
        UpdateSocketInventory();
    }

/*
    private void UpdateBodySocketHeight(bodySocket bodySocket)
    {
        bodySocket.gameObject.transform.position = new Vector3(bodySocket.gameObject.transform.position.x, currentCameraPosition.y * bodySocket.heightRatio, bodySocket.gameObject.transform.position.z);
    }
*/
    private void UpdateSocketInventory()
    {
        transform.position = new Vector3(currentCameraPosition.x, currentCameraPosition.y*0.6f, currentCameraPosition.z);
        transform.rotation = new quaternion(0, currentCameraRotation.y, 0, currentCameraRotation.w);
    }
}
