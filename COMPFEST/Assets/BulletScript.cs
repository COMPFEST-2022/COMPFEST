using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


	public int lifetime = 2;
	private float timer;
	//public AudioClip suaranya;
	//public AudioClip EEK;
	
	void OnCollisionEnter2D(Collision2D target){ //cek tabrakan tanpa is trigger
		if (target.gameObject.tag=="Enemy"){ //jika tabrakan dgn enemy
			Destroy(target.gameObject); //hancurkan enemy tsb
			//GameObject.Find("ObjPG").GetComponent<PengaturGame>().TambahSkor(20);
			//GameObject.Find("ObjPG").GetComponent<PengaturGame>().Bunyikan(EEK);
		}
		Destroy (gameObject); //destroy diri sendiri
	}

	void Update(){
		if(timer == 0) {
			//GameObject.Find("ObjPG").GetComponent<PengaturGame>().Bunyikan(suaranya);
		}
		timer += Time.deltaTime; //count waktu kemunculan
		if(timer > lifetime){ //bila sudah mencapai lifetime			
			timer = 0; //reset timer
			Destroy(gameObject); //hancurkan diri sendiri
		}
	}
}
