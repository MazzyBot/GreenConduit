using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    //TODO change so no code is in update, and less in start

    public float resetSpeed;
    public float timeTillReset;
    public float resetTimeLength;

    public bool canReset;
    public bool reset;

    Collider colli;
    Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        colli = GetComponent<Collider>();
        startPoint = transform.position;

        Quaternion rndRotation = Quaternion.Euler(0, Random.Range(0, 360) * Random.value, 0);
        transform.rotation = rndRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(new Vector3 (player.transform.position.x, 0, player.transform.position.z));
        transform.position = startPoint;

        if (reset == true & canReset == true)
        {
            StartCoroutine(FixHolding());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("grass"))
        {
            canReset = false;
            colli.isTrigger = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("grass"))
        {
            canReset = true;
            StartCoroutine(WaitThenFix());
        }
    }

    IEnumerator WaitThenFix()
    {
        yield return new WaitForSeconds(timeTillReset);
        if(canReset == true)
        {
            reset = true;
        }
    }

    IEnumerator FixHolding()
    {
        colli.isTrigger = true;
        for (int i = 0; i < resetTimeLength; i++)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, rot.eulerAngles.y, 0), resetSpeed * Time.deltaTime);
            yield return null;
        }
        colli.isTrigger = false;
        reset = false;
    }
}
