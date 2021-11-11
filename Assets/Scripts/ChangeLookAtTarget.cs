using UnityEngine;
using System.Collections;

public class ChangeLookAtTarget : MonoBehaviour {

	public GameObject target; // the target that the camera should look at

	private AudioSource[] listSounds;

	void Start() {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}

	// Called when MouseDown on this gameObject
	void OnMouseDown () {
		// change the target of the LookAtTarget script to be this gameobject.
		LookAtTarget.target = target;

		StopSounds();
		// toca a música do planete clickado
		target.GetComponent<AudioSource>().Play();

		// ajusta o zoom
		if(target.transform.localScale.x > 1.5) 
			Camera.main.fieldOfView = 20*target.transform.localScale.x;
		else				
			Camera.main.fieldOfView = 60*target.transform.localScale.x;
	}

	// Para todas músicas
	void StopSounds() {
        listSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in listSounds) {
            audioS.Stop();
        }
    }
}
