using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using System;

public class XMLParser {

	public static FileStream file;

	public static void readFile(String path){
		file = File.OpenRead(path);
	}

	public static GameObject[] gameObjectsThroughXML(){
		String xmlFile = file.ToString ();

		Debug.Log (xmlFile);
		GameObject[] gameObjects = new GameObject[10];

		return gameObjects;
	}

}
