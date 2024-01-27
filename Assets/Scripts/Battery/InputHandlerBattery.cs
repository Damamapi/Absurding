using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiverHandler : MonoBehaviour
{
    public GameObject receiverA;
    public GameObject receiverD;
    public GameObject receiverLeft;
    public GameObject receiverRight;

    private Inputs inputs; // Use the correct class name here

    private void Awake()
    {
        inputs = new Inputs(); // And here

        inputs.Gameplay.P1L.performed += _ => ChangeColor(receiverA, Color.green);
        inputs.Gameplay.P1R.performed += _ => ChangeColor(receiverD, Color.red);
        inputs.Gameplay.P2L.performed += _ => ChangeColor(receiverLeft, Color.blue);
        inputs.Gameplay.P2R.performed += _ => ChangeColor(receiverRight, Color.yellow);
    }

    private void OnEnable()
    {
        inputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputs.Gameplay.Disable();
    }

    private void ChangeColor(GameObject receiver, Color color)
    {
        // This assumes the receiver has an Image component
        var image = receiver.GetComponent<UnityEngine.UI.Image>();
        if (image != null)
        {
            image.color = color;
        }
    }
}
