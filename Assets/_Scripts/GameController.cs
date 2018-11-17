using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField] Image startImage;

    // Use this for initialization
    void Start () {
        if (Score._highScore > 0)
        {
            startImage.gameObject.SetActive(false);
        }
        else
        {
            startImage.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0 && (Input.GetKeyDown(KeyCode.Space)))
        {
            Time.timeScale = 1;
            startImage.gameObject.SetActive(false);
        }
	}
}
