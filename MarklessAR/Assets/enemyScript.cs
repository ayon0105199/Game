using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    public float delayTime = 0f;
    public float speedMultiplier = 0f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speedMultiplier * Time.deltaTime);
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}