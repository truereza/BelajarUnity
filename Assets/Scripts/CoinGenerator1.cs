using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator1 : MonoBehaviour {
	public ObjectPooler coinPool;
	public float distanceBetweenCoins;

	public void SpawnCoins (Vector3 Startposition){
		GameObject coin1 = coinPool.GetPooledObject();
		coin1.transform.position = Startposition;
		coin1.SetActive(true);

		GameObject coin2 = coinPool.GetPooledObject();
		coin2.transform.position = new Vector3(Startposition.x - distanceBetweenCoins, Startposition.y, Startposition.z);
		coin2.SetActive(true);
	}
}
