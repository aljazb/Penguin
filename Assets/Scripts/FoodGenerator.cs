using UnityEngine;
using System.Collections;

public class FoodGenerator : MonoBehaviour {

	public GameObject foodObject;
	public float interval;
	public float spawnRadius;
	public float aboveGround;
	public int startCount;

	void Start () {
		for (int i = 0; i < startCount; i++) {
			generate();
		}
		InvokeRepeating("generate", 0, interval);
	}

	void generate() {
		float x = Random.Range(transform.position.x-spawnRadius, transform.position.x+spawnRadius);
		float z = Random.Range(transform.position.z-spawnRadius, transform.position.z+spawnRadius);
		float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)) + aboveGround;
		GameObject tempFood = (GameObject)Instantiate(foodObject, new Vector3(x, y, z), Quaternion.identity);	
		tempFood.transform.parent = gameObject.transform;
	}
}
