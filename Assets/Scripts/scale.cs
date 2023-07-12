using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sentry;

public class scale : MonoBehaviour
{
    GameObject frog;
    void Start()
    {
        SentrySdk.CaptureMessage("Test event");
        frog = GameObject.Find("frog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScaleDown()
    {
        var transaction = SentrySdk.StartTransaction(
            "test-transaction-name",
            "test-transaction-operation"
            );
        var span = transaction.StartChild("test-child-operation");

        frog.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        span.Finish();
        transaction.Finish();
    }
}
