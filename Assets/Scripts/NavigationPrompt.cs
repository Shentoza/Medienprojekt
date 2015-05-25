using UnityEngine;
using System.Collections;

public class NavigationPrompt : MonoBehaviour {

	bool showDialog;
	// Use this for initialization
	void OnCollisionEnter2D( Collision2D col)
	{
		showDialog = true;
	}
	
	// Update is called once per frame
	void OnCollisionExit2D(Collision2D col)
	{
		if(NavigationManager.CanNavigate(this.tag))
			showDialog = false;
	}

	void OnGUI()
	{
		if (showDialog)
		{
			//layout start
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
			//the menu background box
			GUI.Box(new Rect(0, 0, 300, 250), "");
			// Information text
			GUI.Label(new Rect(15, 10, 300, 68), "Willschde Reisen nach "+NavigationManager.GetRouteInfo(this.tag)+"?");
			//Player wants to leave this location
			if (GUI.Button(new Rect(55, 100, 180, 40), "Na klaro"))
			{
				showDialog = false;
				NavigationManager.NavigateTo(this.tag);
			}

			if (GUI.Button(new Rect(55, 150, 180, 40), "Nääh"))
			{
				showDialog = false;
			}
			//layout end
			GUI.EndGroup();
		}
	}
}