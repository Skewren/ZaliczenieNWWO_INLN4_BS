using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexpos;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB; 
    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexpos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move ()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexpos, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition,nexpos )<=0.1)
        { ChangeDestination(); }

    }
    private void ChangeDestination()
    {
        nexpos = nexpos != posA ? posA : posB;
    }
}
