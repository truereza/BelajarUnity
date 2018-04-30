using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratotTop : MonoBehaviour {
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
	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator1 theCoinGenerator;
	public float randomCoinThreshold;
	public float powerupHeight;
	public ObjectPooler powerupPool;
	public float powerupTreshold;

	// Use this for initialization
	void Start () {
		// platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		platformWidths = new float[theObjectPools.Length];

		for(int i = 0; i<theObjectPools.Length; i++){
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator1>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x){
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range(0, theObjectPools.Length);
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
			
			if(heightChange > maxHeight){
				heightChange = maxHeight;
			}else if(heightChange < minHeight){
				heightChange = minHeight;
			}

			if(Random.Range(0f,100f) < powerupTreshold){
				GameObject newPowerup = powerupPool.GetPooledObject();
				newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(powerupHeight / 2f, powerupHeight), 0f);
				newPowerup.SetActive(true);
			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);
			
			// Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			if(Random.Range(0f,100f) < randomCoinThreshold){
				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y +1f, transform.position.z));
			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
		}
	}
}
