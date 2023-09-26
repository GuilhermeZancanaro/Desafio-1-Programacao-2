using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRef 
{
    public Quaternion rotation;
    public Vector3 position, scale = new Vector3();
    

    static public TransformRef ToTranformRef(GameObject go)
    {
        var tf = go.GetComponent<Transform>();
        var tref = new TransformRef() { position = tf.position, rotation = tf.rotation, scale = tf.localScale };

        return tref;
    }
}
