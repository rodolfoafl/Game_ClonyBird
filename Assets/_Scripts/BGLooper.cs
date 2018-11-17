using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    int numBGPanels = 5;

    private float _maxHeightPipe = 1.75f;
    private float _minHeightPipe = 0.8f;

    void OnTriggerEnter2D(Collider2D collider) {
        //Debug.Log("Triggered: " + collider.name);

        float widthOfBGObject = collider.bounds.size.x;

        Vector3 pos = collider.transform.position;
        pos.x += (widthOfBGObject - 0.015f) * numBGPanels;

        if (collider.CompareTag("Pipes"))
        {
            pos.y = Random.Range(_minHeightPipe, _maxHeightPipe);
        }

        collider.transform.position = pos;
    }
}
