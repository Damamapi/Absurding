using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiverHandler : MonoBehaviour
{
    public GameObject receiverA;
    public GameObject receiverD;
    public GameObject receiverLeft;
    public GameObject receiverRight;

    private GameControls gameControls;

    private void Awake()
    {
        gameControls = new GameControls();

        gameControls.Gameplay.P1L.performed += _ => ChangeColor(receiverA, Color.green);
        gameControls.Gameplay.P1R.performed += _ => ChangeColor(receiverD, Color.red);
        gameControls.Gameplay.P2L.performed += _ => ChangeColor(receiverLeft, Color.blue);
        gameControls.Gameplay.P2R.performed += _ => ChangeColor(receiverRight, Color.yellow);
    }

    private void OnEnable()
    {
        gameControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        gameControls.Gameplay.Disable();
    }

    private void ChangeColor(GameObject receiver, Color color)
    {
        var image = receiver.GetComponent<UnityEngine.UI.Image>();
        if (image != null)
        {
            image.color = color;
        }
    }
}
