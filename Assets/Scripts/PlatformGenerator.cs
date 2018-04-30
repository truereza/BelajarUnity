using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	public ObjectPooler[] theObjectPools;
	public GameObject[] thePlatforms;
	private float[] platformWidths;
	private int platformSelector;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;

	public float randomUrchinThreshold;
	public ObjectPooler UrchinPool;

	// Use this for initialization
	void Start () {
		// platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		platformWidths = new float[theObjectPools.Length];

		for(int i = 0; i<theObjectPools.Length; i++){
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		theCoinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x){
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range(0, theObjectPools.Length);

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
			
			// Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			if(Random.Range(0f,100f) < randomCoinThreshold){
				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
			}

			if(Random.Range(0f,100f) < randomUrchinThreshold){
				GameObject newUrchin = UrchinPool.GetPooledObject();

				float urchinXposition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

				Vector3 urchinPosition = new Vector3(urchinXposition, 1.5f, 0f);

				newUrchin.transform.position = transform.position + urchinPosition;
				newUrchin.transform.rotation = transform.rotation;
				newUrchin.SetActive(true);
			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
		}
	}
}
