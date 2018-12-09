using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Clouds cloudGenerator = transform.parent.GetComponentInParent<Clouds>();
        cloudGenerator.EndClouds();
    }
}
