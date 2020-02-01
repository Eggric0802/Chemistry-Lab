using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScipt : MonoBehaviour {

    public GameObject menu;
    public int currentScene = 0;

	public void practiceLab (string SceneName) {
		Debug.Log("Practice");
        currentScene = 1;
        Application.LoadLevel(SceneName);
	}
	public void testLab (string SceneName) {
		Debug.Log("Test");
        currentScene = 2;
        Application.LoadLevel(SceneName);
	}
	public void Quit(){
		Debug.Log("quit");
		Application.Quit();
        currentScene = 0;
    }
	//public void FixedUpdate(){
		//SceneManager.LoadScene("LabLearn");
	//}
	
}
