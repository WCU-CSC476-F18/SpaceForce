using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public bool cloudsOn = true;    // Controls whether or not we're making clouds

    public float minDelay = 1.0f;   // Minimum amount of time between clouds
    public float maxDelay = 3.0f;   // Maximum amount of time between clouds

    // minDelay and maxDelay will be set to this to produce a crapload of clouds
    // hiding the transition between ground and space
    public float endDelay = 0.1f;
    public float endTime = 3.0f;    // How long the ground/space transition should last

    public GameObject[] clouds; // Holds cloud prefabs 

    public Vector3 startPosition = new Vector3(0f, 15f, -0.5f);
    public float xVariance = 5.0f;  // maximum x distance from center a cloud can spawn

    public GameObject stars;    // Holds a prefab for producing stars
    public float starDelay = 2.0f;
    public Vector3 starStartPosition = new Vector3(-7.5f, 15f, -1.5f); // Prefab is centered on the left star field
    public float maxStarOffset = 5.0f;  // The furthest to the left of start the starfield will spawn

    // Use this for initialization
    void Start () {
        if (cloudsOn)
            MakeCloud();
	}

    private void MakeCloud()
    {
        Vector3 position = startPosition;
        position.x += Random.Range(-xVariance,xVariance);
        GameObject cloudPrefab = clouds[(int)Random.Range(0, clouds.Length)];
        Instantiate(cloudPrefab, position, cloudPrefab.transform.rotation);

        if (cloudsOn)
        {
            Invoke("MakeCloud",Random.Range(minDelay,maxDelay));
        }
    }

    public void EndClouds() //Begins end sequence
    {
        minDelay = endDelay;
        maxDelay = endDelay;
        Invoke("KillClouds",endTime);

        MakeStars();
    }

    public void KillClouds() //Terminates clouds
    {
        cloudsOn = false;
    }

    public void MakeStars()
    {
        Vector3 position = starStartPosition;
        position.x += Random.Range(0f,maxStarOffset);
        Instantiate(stars, position, stars.transform.rotation);

        // Once we start making stars, we keep making them forever
        Invoke("MakeStars", starDelay);
    }
}
