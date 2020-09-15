using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour {
	public void loadMainGame()
	{
		SceneManager.LoadScene (1);
	}
}
