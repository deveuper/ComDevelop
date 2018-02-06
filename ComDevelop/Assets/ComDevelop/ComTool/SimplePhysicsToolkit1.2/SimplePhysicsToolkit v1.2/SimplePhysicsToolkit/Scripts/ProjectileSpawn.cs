using UnityEngine;
using System.Collections;

/* Simple Physics Toolkit - Projectile Spawn
 * Description: Spawns items and fires them (projectile) in the obejct 'forward' direction
 * 				Allows you to tweak emit rate, inaccuracy and speed
 * Required Components: GameObjects (Array) (Projectiles)
 * Author: Dylan Anthony Auty
 * Version: 1.0
 * Last Change: 2017-04-29
*/
public class ProjectileSpawn : MonoBehaviour {

	public bool enabled = true;
	public float inaccuracy = 0.5f;
	public float emitRate = 1.0f;
	public float speed = 1.5f;
	public bool addRandomInertiaToProjectiles = false;

	public GameObject[] objects;

	float time = 0.0f;
	int inertiaCount = 0;
	int inertiaRatio;

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, 0.5f);
		Gizmos.DrawLine (transform.position, transform.position - (transform.forward * 20.0f) );
	}

	void Start(){
		inertiaRatio = Random.Range (5, 15);
	}

	void Update () {
		if (enabled) {
			time += Time.deltaTime;
			if (time > emitRate) {
				Vector3 direction = transform.position - transform.forward + Random.insideUnitSphere * inaccuracy;
				GameObject spawn = getRandom ();

				spawnObject (spawn, direction);
				time = 0.0f;
			}
		}
	}

	void spawnObject(GameObject spawn, Vector3 direction){
		GameObject activeObject = (GameObject) Instantiate (spawn, transform.position, transform.rotation);
		activeObject.transform.LookAt (direction);

		if (activeObject.GetComponent<Rigidbody> () == null) {
			activeObject.AddComponent<Rigidbody> ();
		}

		Rigidbody rigid = activeObject.GetComponent<Rigidbody> ();
		rigid.AddForce (activeObject.transform.forward * speed * 1000.0f);

		if (addRandomInertiaToProjectiles) {
			if (inertiaCount >= inertiaRatio) {
				//Add inertia
				rigid.AddRelativeTorque (activeObject.transform.up * 150.0f);
				inertiaCount = 0;
				inertiaRatio = Random.Range (5, 15);
			}
			inertiaCount++;
		}
	}

	GameObject getRandom(){
		return objects [Random.Range (0, objects.Length - 1)];
	}
}
