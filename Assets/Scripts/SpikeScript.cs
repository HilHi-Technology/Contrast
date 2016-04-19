using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
