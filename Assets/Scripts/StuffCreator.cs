using UnityEngine;
using System.Collections;

public class StuffCreator : MonoBehaviour {

    public GameObject[] enemiesPrefabs;
    public GameObject[] itemsPrefabs;
    public GameObject planet;

    [Header("Spawn Seconds")]
    public float spawnSecondsMin;
    public float spawnSecondsMax;
    private float timeElapsed;

	// Use this for initialization
	void Start () {
        timeElapsed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        float spawnRandom = Random.Range(spawnSecondsMin, spawnSecondsMax);
	    if ( timeElapsed > spawnRandom) {
            timeElapsed = 0f;
            Instantiate(itemsPrefabs[Random.Range(0, itemsPrefabs.Length)], transform.position, transform.rotation, planet.transform);
        }
	}
}
