using System;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketChecker : MonoBehaviour
{

    [SerializeField]
    private XRSocketTagInteractor keySocket;

    [SerializeField]
    private GameObject correctKey;

    private GameObject socketKey;
    
    [HideInInspector]
    public bool correct = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log("Start of Fixed Update");

        // Hvis den så stopper metoden med at køre fordi at den smider en exeption, derfor sætter vi correct til false hvis der kommer en exeption.
        try
        {
            socketKey = keySocket.interactablesSelected[0].transform.gameObject;
        }
        catch(ArgumentOutOfRangeException e)
        {
            correct = false;
        }


        if (socketKey.name == correctKey.name && socketKey.name != null)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }

        socketKey = null;
    }
}
