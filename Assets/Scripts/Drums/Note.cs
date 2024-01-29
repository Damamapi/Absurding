using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool hasBeenHit = false;
    public float spawnTime;
    float fallSpeed = 8f;
    public void SpawnNote(int type, float time)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        spawnTime = time;

        switch (type)
        {
            case 1:
                this.transform.position = new Vector3(-6, 6, 0);
                sprite.color = new Color(33 / 255f, 214 / 255f, 42 / 255f, 1f);
                break;

            case 2:
                this.transform.position = new Vector3(-3, 6, 0);
                sprite.color = new Color(214 / 255f, 58 / 255f, 58 / 255f, 1f);
                break;

            case 3:
                this.transform.position = new Vector3(3, 6, 0);
                sprite.color = new Color(212 / 255f, 202 / 255f, 37 / 255f, 1f);
                break;

            case 4:
                this.transform.position = new Vector3(6, 6, 0);
                sprite.color = new Color(45 / 255f, 67 / 255f, 221 / 255f, 1f);
                break;

            default:
                Debug.Log("Something went wrong");
                break;
        }
    }
    private void FixedUpdate()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

        this.transform.position = transform.position - new Vector3(0, fallSpeed/60, 0);
    }
}
