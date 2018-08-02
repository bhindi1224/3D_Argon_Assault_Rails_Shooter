using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

	[SerializeField] private float delay = 3f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		print(Time.time);
		if (Time.time > delay)
		{
			int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(currentSceneIndex+1);
		}
		
	}
}
