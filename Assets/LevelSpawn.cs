using UnityEngine;
using System.Collections;

public class LevelSpawn : MonoBehaviour {
	public GameObject levelGroup;
	public int spawnTime;
	float timer;
	bool spawned;
	bool fadingOut;
	bool fadingIn;
	GameObject oldRayCaster;
	GameObject oldLight;
	public Light oldDirLight;
	public Light newDirLight;
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
			fadingOut = true;


//			Instantiate(levelGroup);

		}

		if (fadingOut && oldDirLight.intensity > .1)
		{
			Debug.Log("Light Intensity: " + oldDirLight.intensity);
			oldDirLight.intensity = Mathf.Lerp(oldDirLight.intensity, 0f, 1f * Time.deltaTime);


			if (oldDirLight.intensity < .1)
			{
				oldDirLight.intensity = 0;
				fadingOut = false;
				Destroy(oldRayCaster);
				Instantiate(levelGroup);
				spawned = true;
				fadingIn = true;
			}
		}

		if (fadingIn) 
		{
			newDirLight.intensity = Mathf.Lerp(newDirLight.intensity, 8f, .1f * Time.deltaTime);
			Debug.Log ("New light intensity: " + newDirLight.intensity);
			if (newDirLight.intensity > 7.9)
			{
				newDirLight.intensity = 8;
				fadingIn = false;
			}

		}


	}
}
