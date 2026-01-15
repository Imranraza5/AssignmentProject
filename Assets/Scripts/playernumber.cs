using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playernumber : MonoBehaviour
{
    public int number = 1;
    public TMP_Text numberText;

    public GameObject tailPrefab;
    public float followDistance = 0.6f;
    public float followSpeed = 8f;

    private List<tailsegment> activeTail = new List<tailsegment>();
    private Queue<tailsegment> pool = new Queue<tailsegment>();

    void Start()
    {
        UpdatePlayerUI();
        BuildTail();
    }

    void Update()
    {
        MoveTail();
    }

    public void UpdateNumber(int amount)
    {
        number += amount;
        if (number < 1) number = 1;

        UpdatePlayerUI();
        BuildTail();
    }

    void UpdatePlayerUI()
    {
        numberText.text = number.ToString();
    }

   void BuildTail()
{
    int required = number - 1;

    if (required < 0) required = 0;

    // REMOVE from BACK
    while (activeTail.Count > required)
    {
        tailsegment seg = activeTail[activeTail.Count - 1];
        activeTail.RemoveAt(activeTail.Count - 1);
        seg.Disable();
        pool.Enqueue(seg);
    }

    // ADD if needed
    while (activeTail.Count < required)
    {
        tailsegment seg = GetFromPool();
        activeTail.Add(seg);
    }

    // UPDATE values (top-down)
    for (int i = 0; i < activeTail.Count; i++)
    {
        activeTail[i].Setup(number - (i + 1));
    }
}

    tailsegment GetFromPool()
    {
        if (pool.Count > 0)
            return pool.Dequeue();

        GameObject obj = Instantiate(tailPrefab);
        return obj.GetComponent<tailsegment>();
    }

    void MoveTail()
    {
        Vector3 prevPos = transform.position;

        for (int i = 0; i < activeTail.Count; i++)
        {
            Vector3 targetPos = prevPos - transform.forward * followDistance;
            activeTail[i].transform.position =
                Vector3.Lerp(activeTail[i].transform.position, targetPos, Time.deltaTime * followSpeed);

            prevPos = activeTail[i].transform.position;
        }
    }
}