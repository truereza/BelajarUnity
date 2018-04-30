using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {
	public ObjectPooler coinPool;
	public float distanceBetweenCoins;

	public void SpawnCoins (Vector3 Startposition){
		GameObject coin = coinPool.GetPooledObject();
		coin.transform.position = Startposition;
		coin.SetActive(true);

		GameObject coin2 = coinPool.GetPooledObject();
		coin2.transform.position = new Vector3(Startposition.x - distanceBetweenCoins, Startposition.y, Startposition.z);
		coin2.SetActive(true);

		GameObject coin3 = coinPool.GetPooledObject();
		coin3.transform.position = new Vector3(Startposition.x + distanceBetweenCoins, Startposition.y, Startposition.z);
		coin3.SetActive(true);
	}
}
