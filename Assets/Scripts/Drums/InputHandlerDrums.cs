using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class InputHandlerDrums : MonoBehaviour
{
    public GameObject receiverA;
    public GameObject receiverD;
    public GameObject receiverLeft;
    public GameObject receiverRight;

    public List<GameObject> activeNotesA;
    public List<GameObject> activeNotesD;
    public List<GameObject> activeNotesLeft;
    public List<GameObject> activeNotesRight;

    public float hitWindow = 0.2f;
    public float delay = 2.22f;

    private Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();

        inputs.Gameplay.P1L.performed += _ => Register(receiverA, activeNotesA);
        inputs.Gameplay.P1R.performed += _ => Register(receiverD, activeNotesD);
        inputs.Gameplay.P2L.performed += _ => Register(receiverLeft, activeNotesLeft);
        inputs.Gameplay.P2R.performed += _ => Register(receiverRight, activeNotesRight);
    }

    private void OnEnable()
    {
        inputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputs.Gameplay.Disable();
    }

    private void Register(GameObject receiver, List<GameObject> activeNotes)
    {
        float currentTime = Time.timeSinceLevelLoad;
        receiver.transform.localScale *= 1.2f;

        Note n = activeNotes[0].GetComponent<Note>();

        if ( Mathf.Abs(currentTime - n.spawnTime + delay) < hitWindow)
        {

        }


        StartCoroutine(ReturnToSize(receiver));        
    }

    private void Update()
    {
        CheckIfMissed(activeNotesA);
        CheckIfMissed(activeNotesD);
        CheckIfMissed(activeNotesRight);
        CheckIfMissed(activeNotesLeft);
    }

    public void CheckIfMissed(List<GameObject> notes)
    {
        float currentTime = Time.timeSinceLevelLoad;
        if (notes.Count <= 0) return;
        Note n = notes[0].GetComponent<Note>();
        if (!n.hasBeenHit && (n.spawnTime + delay - currentTime - hitWindow < 0))
        {
            Debug.Log("Note missed, should have been played at " + (n.spawnTime + delay) + ", it is currently: " + currentTime);
            n.hasBeenHit = true;
            notes.RemoveAt(0);
        }
    }

    IEnumerator ReturnToSize(GameObject receiver)
    {
        yield return new WaitForSeconds(0.05f);
        receiver.transform.localScale /= 1.2f;
    }
}
