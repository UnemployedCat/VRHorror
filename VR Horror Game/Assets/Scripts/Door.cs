using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private Vector3 openDirection; // Existere fordi vi har et skill issue og ikke kan finde ud af at sætte en Vector3 variable

    [SerializeField]
    private AudioSource openCloseSound;

    private Vector3 originalPosition;

    [SerializeField]
    private List<GameObject> keySockets;

    private int correctKeys;

    private bool open = false;

    void Awake()
    {
        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        correctKeys = 0;
        foreach (GameObject gameObject in keySockets)
        {
            Debug.Log(gameObject.name + " Is Correct " + gameObject.GetComponent<SocketChecker>().correct);
            if (gameObject.GetComponent<SocketChecker>().correct)
            {
             correctKeys++;
            }
        }

        Debug.Log("Amount of Correct Keys " + correctKeys);
        Debug.Log("is Open " + open);
        if (correctKeys == keySockets.Count && !open)
        {   
            Debug.Log("Open");
            OpenDoor();
            open = true;
        }
        else if (open && !(correctKeys == keySockets.Count))
        {
            Debug.Log("Close");
            CloseDoor();
            open = false;
        }
    }


    void OpenDoor()
    {
        this.transform.position += openDirection;
        openCloseSound.Play();
    }

    void CloseDoor()
    {
        this.transform.position = originalPosition;
        openCloseSound.Play();
    }
}
