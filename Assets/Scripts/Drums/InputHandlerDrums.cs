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

    public List<Note> activeNotesA;
    public List<Note> activeNotesD;
    public List<Note> activeNotesLeft;
    public List<Note> activeNotesRight;

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

    private void Register(GameObject receiver, List<Note> activeNotes)
    {
        receiver.transform.localScale *= 1.2f;
        StartCoroutine(ReturnToSize(receiver));

    }

    private void Update()
    {
        CheckIfMissed(activeNotesA);
        CheckIfMissed(activeNotesD);
        CheckIfMissed(activeNotesRight);
        CheckIfMissed(activeNotesLeft);
    }

    public void CheckIfMissed(List<Note> notes)
    {
        if (notes.Count <= 0) return;
        if (!notes[0].hasBeenHit && Mathf.Abs(Time.timeSinceLevelLoad - notes[0].spawnTime + delay) > hitWindow)
        {
            Debug.Log("Note missed");
            notes[0].hasBeenHit = true;
            notes.RemoveAt(0);
        }
    }

    IEnumerator ReturnToSize(GameObject receiver)
    {
        yield return new WaitForSeconds(0.05f);
        receiver.transform.localScale /= 1.2f;
    }
}
