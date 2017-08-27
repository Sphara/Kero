using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoluteTowardsTarget : MonoBehaviour {

    public GameObject Target;
    public Transform[] Joins;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate() {
        float SamplingDistance = 1;
        float LearningGradient = 10;

        Vector3[] axes = new Vector3[]{ Vector3.up, Vector3.left, Vector3.back };

        foreach (Vector3 axis in axes)
        {
            foreach (Transform t in Joins)
            {
                float f = Vector3.Distance(transform.position, Target.transform.position) + 0.02f * Vector3.Angle(Vector3.up, -transform.forward) + Mathf.Abs(transform.parent.rotation.w - transform.rotation.w);

                t.Rotate(axis, SamplingDistance);
                float g = Vector3.Distance(transform.position, Target.transform.position) + 0.02f * Vector3.Angle(Vector3.up, -transform.forward) + Mathf.Abs(transform.parent.rotation.w - transform.rotation.w);
                t.Rotate(axis, -SamplingDistance);

                if (Mathf.Abs(g - f) >= 0.02f)
                {
                    g = LearningGradient * (g - f) / SamplingDistance;
                    t.Rotate(axis, -g);
                }
            }
        }
    }
}
