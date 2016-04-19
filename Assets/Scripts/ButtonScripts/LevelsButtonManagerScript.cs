using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsButtonManagerScript : MonoBehaviour {
    public int maxHorAmount;  // How many buttons can be placed horizontally.
    // All distances are in screen space.
    public int xPadding;  // Distance from each buttons/
    
    public int yPadding;
    public int xOffset;  // Distance from starting edge of screen.
    public int yOffset;
    public List<Transform> ButtonList;
     
	// Use this for initialization
	void Start () {
        float screenHeight = Camera.main.ViewportToScreenPoint(Vector2.one).y;
        int c = 0;
        int y = 0;
        while(true){
            for(int x = 0; x < maxHorAmount; x++){
                ButtonList[c].position = Camera.main.ScreenToWorldPoint(new Vector3(x*xPadding + xOffset, screenHeight - (y*yPadding + yOffset), 10));
                c++;
                if(c >= ButtonList.Count) break;
            }
            if(c >= ButtonList.Count) break;
            y++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
