using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGInitializer : MonoBehaviour {

    [SerializeField] BoxCollider2D bgPanelSky;
    [SerializeField] BoxCollider2D bgPanelGround;
    [SerializeField] BoxCollider2D bgPipes;

    private float _maxHeightPipe = 1.75f;
    private float _minHeightPipe = 0.8f;

    // Use this for initialization
    void Start () {
        InstantiateAtEndOf2DObject(bgPanelSky, 5);
        InstantiateAtEndOf2DObject(bgPanelGround, 5);
        InstantiateAtEndOf2DObject(bgPipes, 5);
    }

    void InstantiateAtEndOf2DObject(Collider2D collider, int amount)
    {
        float widthOfBGObject = collider.bounds.size.x;
        for (int i = 1; i < amount; i++)
        {
            var obj = Instantiate(collider, collider.transform.parent);
            Vector3 pos = collider.transform.position;
            Debug.Log(collider.name);
            if (collider.name.Contains("sky"))
            {
                pos.x += widthOfBGObject - 0.015f;   //Subtração feita devido ao asset mal cortado que causa 'buraco' entre tiles
                widthOfBGObject += obj.bounds.size.x - 0.015f;
            }
            else
            {
                pos.x += widthOfBGObject;
                widthOfBGObject += obj.bounds.size.x;
            }

            if (collider.CompareTag("Pipes"))
            {
                pos.y = Random.Range(_minHeightPipe, _maxHeightPipe);
            }

            obj.transform.position = pos;
        }
    }

}
