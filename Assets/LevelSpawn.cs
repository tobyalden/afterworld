using UnityEngine;
using System.Collections;

public class LevelSpawn : MonoBehaviour {
	public GameObject levelGroup;
	public int spawnTime;
	float timer;
	bool spawned;
	GameObject oldRayCaster;
	GameObject oldLight;
	// Use this for initialization
	void Start () {
		timer = 0;
		oldRayCaster = GameObject.Find("raycaster");
		oldLight = GameObject.Find("SunLevel0");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Debug.Log(timer);

		if (timer >= spawnTime && !spawned)
		{
			spawned = true;
			Destroy(oldRayCaster);
			Destroy(oldLight);
			Instantiate(levelGroup);

		}

	}
}
