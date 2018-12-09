using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {
    // This behavior is shared by ground terrain, clouds, and stars, to enable constant movement
    public bool isMoving = true;
    public float speed = 10f;
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            Vector3 curPos = this.gameObject.transform.position;
            Vector3 newPos = new Vector3(curPos.x, curPos.y - (speed*Time.deltaTime), curPos.z);
            this.gameObject.transform.position = newPos;
        }
	}
}
