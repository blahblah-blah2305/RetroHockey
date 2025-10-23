/*using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectUI : MonoBehaviour{

	//Build Index of the Currently Loaded scene
	private int currentScene = 0;
	//Current scenes level view camera,
	private GameObject levelViewCamera;
	//current ongoing scene loading operation
	private AsyncOperation currentLoadOperation;

void start(){
	DontDestroyOnLoad(gameObject);
}

void PlayCurrentLevel(){
	//Deactivate the level view camera
	levelViewCamera.SetActive(false);
	//find player camera
	var playerGobj = GameObject.Find("Puck");
	//error if not found
	if (playerGobj == null){
		Debug.LogError("Couldnt find the puck!");
	}
	else{
		var playerScript = playerGobj.GetComponent<PuckScript>();
		//get the player script attached and enable it
		playerScript.enabled = true;
		//through puck script access the camera GameObject
		playerScript.cam.SetActive(true);
		//destroy self
		Destroy(this.gameObject);
	}
}

void OnGUI(){

	GUILayout.Label("RETROHOCKEY");

	if ( currentScene != 0 ){
		GUILayout.Label("Currently viewing level " + currentScene);
		//play button
		if (GUILayout.Button("PLAY")){
			PlayCurrentLevel();
		}
	}
	else //main menu
		GUILayout.Label("Select a level");
	// starting at scene build index 1, loop through the remaining scenes
	for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++){
		if (GUILayout.Button("Level "+ i)){
			if (currentLoadOperation == null){
				//Start loading asynchronously
				currentLoadOperation = SceneManager.LoadSceneAsync(i);
				//set the current scene;
				currentScene = i;

			}
		}
	}

}

void Update(){

	//if current load operation and its done
	if(currentLoadOperation != null && currentLoadOperation.isDone){
		//NUll the load operation
		currentLoadOperation = null;
		levelViewCamera = Gameobject.Find("Level View Camera");
		if (levelViewCamera == null){
			Debug.LogError("NO level view camera found in the scene");
		}


	}

} 
}*/
