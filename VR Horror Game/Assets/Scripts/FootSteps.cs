using UnityEngine;
using UnityEngine.InputSystem;

public class FootSteps : MonoBehaviour
{

    public InputActionProperty move;

    public GameObject footStepSound;

    private bool moving;

    // Update is called once per frame
    void FixedUpdate()
    {
        moving = move.action.IsPressed();

        if (moving)
        {
            footStepSound.SetActive(true);
        }
        else
        {
            footStepSound.SetActive(false);
        }
    }
}
