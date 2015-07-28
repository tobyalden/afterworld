using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	
	public bool inLight;
	public float maxHealth;
	public float currentHealth;
	public bool alive;
	
	// Use this for initialization
	void Start () {
		inLight = false;
		currentHealth = maxHealth;
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		inLight = false;
		
		var rayCaster = GameObject.FindWithTag("Sun");
		
		// Check if the player's head is in light
		
		RaycastHit torsoInfo;
		if(Physics.Linecast(transform.position, rayCaster.transform.position, out torsoInfo))
		{
			if (torsoInfo.collider.tag == "Sun") 
			{
				inLight = true;
			}
		}
		
//		 Check if the player's feet are in light
		Ray torsoToFeet = new Ray(transform.position, -Vector3.up);
		RaycastHit feetInfo;
			
		if (Physics.Raycast(torsoToFeet, out feetInfo))
		{
			RaycastHit sunbeamInfo;
			if(Physics.Linecast (rayCaster.transform.position, feetInfo.point, out sunbeamInfo))
			{
				if(V3Equal(sunbeamInfo.point, feetInfo.point)) 
				{
					inLight = true; 
				} 
			}
		}

		if (inLight)
		{
			currentHealth += Time.deltaTime * 5;

			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}

		}
		else
		{
			currentHealth -= Time.deltaTime * 10;

			if (currentHealth < 0)
			{
				alive = false;	
			}

		}


	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10f, 10f, Screen.width, Screen.height));	
		GUILayout.Label("Health:  " + (int)currentHealth + "/" + maxHealth);
		GUILayout.Label("Alive: " + alive);
		GUILayout.EndArea();
	}

	public bool V3Equal(Vector3 a, Vector3 b){
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}
	
}