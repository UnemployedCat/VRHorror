using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    public List<GameObject> startRooms;
    public List<GameObject> bloodRooms;
    public List<GameObject> foodRooms;
    public List<GameObject> vomitRooms;
    public List<GameObject> longHallwayRoom;


    private List<GameObject>[] rooms = new List<GameObject>[5];


    [SerializeField]
    private int triggersToActivateOnAwake;

        
    public List<GameObject> inactiveTriggers;
    public List<GameObject> activeTriggers;

    void Awake()
    {
        rooms = new List<GameObject>[] {startRooms, bloodRooms, foodRooms, vomitRooms, longHallwayRoom};
        
        int integer = 0;

        foreach (List<GameObject> room in rooms)
        {
            foreach (GameObject trigger in room)
            {
                inactiveTriggers.Add(trigger);
                trigger.GetComponent<AnimationTrigger>().roomID = integer;
            }

            integer++;
        }

        foreach (GameObject trigger in inactiveTriggers)
        {
            trigger.SetActive(false);   
        }

        
        for (int i = 0; i < triggersToActivateOnAwake; i++)
        {
            NewActiveTrigger();
        }

    }

    public void NewActiveTrigger()
    {
        bool loop = true;

        int room = 0;
        int trigger = 0;
        while (loop)
        {
        int counter = 0;
        room = Random.Range(0, rooms.Length);
        trigger = Random.Range(0, rooms[room].Count);


        foreach (GameObject gameObject in activeTriggers)
        {
            if (gameObject.GetComponent<AnimationTrigger>().roomID == room)
            {
                counter++;
            }
        }
        if (counter == 0)
        {
            loop = false;
        }
        }

        rooms[room][trigger].SetActive(true);
        activeTriggers.Add(rooms[room][trigger]);
        inactiveTriggers.Remove(rooms[room][trigger]);
        
    }




}
