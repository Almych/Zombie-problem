using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speedCoin = 8f;
    private const float takeTime = 2f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CoinCollect());
    }

    public IEnumerator CoinCollect()
    {
        yield return new WaitForSeconds(takeTime);
        rb.velocity = -Vector3.right * speedCoin;
    }
}
