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

    private List<tailsegment> tail = new List<tailsegment>();

    void Start()
    {
        UpdatePlayerUI();
        RebuildTail();
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
        RebuildTail();
    }

    void UpdatePlayerUI()
    {
        numberText.text = number.ToString();
    }

    // 🔥 CORE LOGIC
    void RebuildTail()
    {
        // remove old tail
        foreach (var seg in tail)
            Destroy(seg.gameObject);

        tail.Clear();

        // build new tail: number-1 → 1
        for (int i = number - 1; i >= 1; i--)
        {
            GameObject obj = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            tailsegment seg = obj.GetComponent<tailsegment>();
            seg.SetValue(i);
            tail.Add(seg);
        }
    }

    void MoveTail()
    {
        Vector3 prevPos = transform.position;

        for (int i = 0; i < tail.Count; i++)
        {
            Vector3 targetPos = prevPos - transform.forward * followDistance;
            tail[i].transform.position =
                Vector3.Lerp(tail[i].transform.position, targetPos, Time.deltaTime * followSpeed);

            prevPos = tail[i].transform.position;
        }
    }
}