using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.MusicTheory;

public class InputHandlerDrums : MonoBehaviour
{
    public GameObject receiverA;
    public GameObject receiverD;
    public GameObject receiverLeft;
    public GameObject receiverRight;

    public List<(GameObject, Note)> activeNotesA = new List<(GameObject, Note)>();
    public List<(GameObject, Note)> activeNotesD = new List<(GameObject, Note)>();
    public List<(GameObject, Note)> activeNotesLeft = new List<(GameObject, Note)>();
    public List<(GameObject, Note)> activeNotesRight = new List<(GameObject, Note)>();

    public float hitWindow = 0.2f;
    public float delay = 2.5f;

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

    private void Register(GameObject receiver, List<(GameObject, Note)> activeNotes)
    {
        float currentTime = Time.timeSinceLevelLoad;
        receiver.transform.localScale *= 1.2f;

        Note n = activeNotes[0].Item2;

        Debug.Log("Hit registered at " + currentTime + " for note at " + (n.spawnTime + delay));

        if ( Mathf.Abs(currentTime - n.spawnTime + delay) < hitWindow)
        {
            GameObject.Destroy(activeNotes[0].Item1);
            activeNotes.RemoveAt(0);
        }

        StartCoroutine(ReturnToSize(receiver));
    }

    private void Update()
    {
        if (activeNotesA.Count > 0) CheckIfMissed(activeNotesA);
        if (activeNotesD.Count > 0) CheckIfMissed(activeNotesD);
        if (activeNotesRight.Count > 0) CheckIfMissed(activeNotesRight);
        if (activeNotesLeft.Count > 0) CheckIfMissed(activeNotesLeft);
    }

    public void CheckIfMissed(List<(GameObject, Note)> notes)
    {
        float currentTime = Time.timeSinceLevelLoad;

        if (notes.Count > 0)
        {
            Note n = notes[0].Item2;
            if (!n.hasBeenHit && (currentTime > n.spawnTime + delay + hitWindow))
            {
                Debug.Log("Note missed, should have been played at " + (n.spawnTime + delay) + ", it is currently: " + currentTime);
                n.hasBeenHit = true;
                GameObject.Destroy(notes[0].Item1);  
                notes.RemoveAt(0);  
            }
        }
    }


    IEnumerator ReturnToSize(GameObject receiver)
    {
        yield return new WaitForSeconds(0.05f);
        receiver.transform.localScale /= 1.2f;
    }
}
