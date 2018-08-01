using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour
{

	// 弾のプレハブ
    public GameObject bulletPrefab;

    // 弾を撃つ間隔
    public float shotDelay;

    void Start ()
    {
    	// 弾をうつ（コルーチン）
        StartCoroutine (Shoot ());
	}

    IEnumerator Shoot ()
    {
    	while (true) {

			// shotDelay秒待つ
        	yield return new WaitForSeconds (shotDelay);

        	// 子要素を全て取得する
        	foreach (Transform child in transform) {

        		long start = System.DateTime.Now.Ticks;
            	// ShotPositionの位置/角度で弾を撃つ
            	Instantiate (bulletPrefab, child.transform.position, child.transform.rotation);

            	// 処理時間でInstantiateとObjectPoolを比較してみる
            	Debug.Log (System.DateTime.Now.Ticks - start);
        	}
        }
	}
}