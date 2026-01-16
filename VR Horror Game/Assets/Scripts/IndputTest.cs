using UnityEngine;
using UnityEngine.InputSystem;

public class IndputTest : MonoBehaviour
{

    public InputActionProperty testActionValue;
    public InputActionProperty testActionButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float value = testActionValue.action.ReadValue<float>();
        Debug.Log($"Value:{value}");

        bool button = testActionButton.action.IsPressed();
        Debug.Log($"Value:{button}");
    }
}
