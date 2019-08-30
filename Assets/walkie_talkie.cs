using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;


public class walkie_talkie : MonoBehaviour {


	void Awake(){
		AirConsole.instance.onReady += OnReady;
		AirConsole.instance.onMessage += OnMessage;
	}
	
	void OnReady(string code){

	}
	void OnMessage (int from, JToken message){
		Debug.Log ("received message from device " + from + ". content: " + message);
		if(message["action"].ToString() == "up"){
			Debug.Log("sending message");
			List<int> controllerIDs = AirConsole.instance.GetControllerDeviceIds ();

			for (int i = 0; i < controllerIDs.Count; ++i){
				Debug.Log("controllerIDs["+i+"] = "+ controllerIDs[i]);
			}
			Debug.Log("player 0 id:"+AirConsole.instance.ConvertPlayerNumberToDeviceId(0));
			Debug.Log("player 1 id:"+AirConsole.instance.ConvertPlayerNumberToDeviceId(1));
			Debug.Log("player 2 id:"+AirConsole.instance.ConvertPlayerNumberToDeviceId(2));
										AirConsole.instance.Message(
											1,//AirConsole.instance.ConvertPlayerNumberToDeviceId(0), 
											"hello world[0]");
										AirConsole.instance.Message(
											2,//AirConsole.instance.ConvertPlayerNumberToDeviceId (1) , 
											"hello world[1]");
										AirConsole.instance.Message(
											3,//AirConsole.instance.ConvertPlayerNumberToDeviceId (2) , 
											"hello world[2]");

			AirConsole.instance.Broadcast("hello world");
		}
		else{
			Debug.Log("sending message failed");
		}
	}
	
	void OnDestroy() {
		if (AirConsole.instance != null) {
			AirConsole.instance.onReady -= OnReady;
			AirConsole.instance.onMessage -= OnMessage;
		}
	}
	// // Use this for initialization
	// void Start () {
	// }
	// // Update is called once per frame
	// void Update () {
	// }
}
