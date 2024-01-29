using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class NoteSpawner : MonoBehaviour
{
    public AudioSource source;
    public float delay;
    public GameObject notePrefab;
    public TextMeshProUGUI timerText;
    private List<(float, int)> noteTimings; // List to store note timings and types
    private int noteIndex = 0; // Index to keep track of the next note to spawn

    public InputHandlerDrums inputHandler;

    string[] midiPaths = new string[] {
        "Assets/Audio/Music/Nivel Batería/midis/Kick_Bombo.mid",
        "Assets/Audio/Music/Nivel Batería/midis/Snare_Redoblante.mid",
        "Assets/Audio/Music/Nivel Batería/midis/Hihat_Closed_Baqueta.mid",
        "Assets/Audio/Music/Nivel Batería/midis/Hihat_Open_Pedal.mid"
    };
    float tickDuration = 60f / (120f * 96f);
    float elapsedTime = 0f;

    void Start()
    {
        noteTimings = new List<(float, int)>();
        for (int i = 0; i < midiPaths.Length; i++) 
        {
            MidiFile midi = MidiFile.Read(midiPaths[i]);
            var notes = ParseMidi(midi, i+1);
            noteTimings.AddRange(notes);
        }
        // Sort notes by time
        noteTimings.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        source.PlayDelayed(delay);
    }
    private List<(float, int)> ParseMidi(MidiFile midiFile, int type)
    {
        List<(float, int)> noteList = new List<(float, int)>();

        foreach (var trackChunk in midiFile.GetTrackChunks())
        {
            var notes = trackChunk.GetNotes();

            foreach (var note in notes)
            {
                float noteTime = note.Time * tickDuration;
                noteList.Add((noteTime, type)); // Assuming type 1 for now
            }
        }

        return noteList;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString() + " " + Time.timeSinceLevelLoad.ToString();

        // Check and spawn notes
        while (noteIndex < noteTimings.Count && elapsedTime >= noteTimings[noteIndex].Item1)
        {
            InstanceNote(noteTimings[noteIndex].Item2, noteTimings[noteIndex].Item1);
            noteIndex++;
        }
    }

    private void InstanceNote(int type, float time)
    {
        GameObject note = Instantiate(notePrefab, new Vector3(0, 10, 0), Quaternion.identity);
        Note n = note.GetComponent<Note>();
        n.SpawnNote(type, time);

        switch (type)
        {
            case 1:
                inputHandler.activeNotesA.Add((note, n));
                break;
            case 2:
                inputHandler.activeNotesD.Add((note, n));
                break;
            case 3:
                inputHandler.activeNotesLeft.Add((note, n));
                break;
            case 4:
                inputHandler.activeNotesRight.Add((note, n));
                break;
            default:
                break;
        }
    }
}
