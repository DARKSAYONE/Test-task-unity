using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isCollected = false;
    private LabyrinthKey labyrinthKey;

    private void Awake()
    {
        labyrinthKey = GetComponentInParent<LabyrinthKey>();
        if (labyrinthKey != null)
        {
            labyrinthKey.RegisterKey(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.GetComponent<Ball>() != null)
        {
            isCollected = true;
            if (labyrinthKey != null)
            {
                labyrinthKey.CollectKey(gameObject);
            }
            Debug.Log("Key trigger activated by Ball.");
        }
    }
}