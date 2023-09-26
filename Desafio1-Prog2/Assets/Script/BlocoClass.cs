using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoClass
{
    public ObjectType obType;
    public string obTypeString;
    public Collider clld;
    public Color color;
    public TransformRef tfmRF;
    public System.Type[] components;

    //Constructors do objeto.
    public BlocoClass(ObjectType obTypee, Collider collider, Color color1, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        var go = obTypee.go; 
        if(go.TryGetComponent(out Renderer renderer) == true)
        {
            go.GetComponent<Renderer>().material.color = color1; 
        }
        else
        {
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<Renderer>().material.color = color1; 
        }
        
        go.transform.position = position;
        go.transform.rotation = rotation;
        go.transform.localScale = scale;

       
        if (collider == Collider.Collider)
        {
            if (go.TryGetComponent(out UnityEngine.Collider collider1) == false)
            {
                go.AddComponent<BoxCollider>();
            }
            go.GetComponent<UnityEngine.Collider>().isTrigger = false;
        }
        else if (collider == Collider.Trigger)
        {
            if (go.TryGetComponent(out UnityEngine.Collider collider1) == false)
            {
                go.AddComponent<BoxCollider>();
            }
            go.GetComponent<UnityEngine.Collider>().isTrigger = true;
        }
        else if (collider == Collider.None)
        {
            Debug.Log("Objeto " + go.name + " sem colisao");
        }

        
        color = go.GetComponent<Renderer>().material.color;
        obType = obTypee;
        obTypeString = obTypee.get.ToString();
        clld = collider;
        tfmRF = TransformRef.ToTranformRef(go);
    }

    public BlocoClass(string obTypee, Collider collider, Color color1, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        var go = ObjectType.WTypeOb(obTypee).go; 
        if (go.TryGetComponent(out Renderer renderer) == true)
        {
            go.GetComponent<Renderer>().material.color = color1; 
        }
        else
        {
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<Renderer>().material.color = color1; 
        }

        go.transform.position = position;
        go.transform.rotation = rotation;
        go.transform.localScale = scale;

        
        if (collider == Collider.Collider)
        {
            if (go.TryGetComponent(out UnityEngine.Collider collider1) == false)
            {
                go.AddComponent<BoxCollider>();
            }
            go.GetComponent<UnityEngine.Collider>().isTrigger = false;
        }
        else if (collider == Collider.Trigger)
        {
            if (go.TryGetComponent(out UnityEngine.Collider collider1) == false)
            {
                go.AddComponent<BoxCollider>();
            }
            go.GetComponent<UnityEngine.Collider>().isTrigger = true;
        }

        
        color = go.GetComponent<Renderer>().material.color;
       
        obTypeString = obTypee;
        clld = collider;
        tfmRF = TransformRef.ToTranformRef(go);
    }

    
    public ObjectSaveDTO GetSaveData()
    {
        var save = new ObjectSaveDTO()
        {
            obTypeString = this.obTypeString,
            clld = this.clld,
            color = this.color,
            position = this.tfmRF.position,
            rotation = this.tfmRF.rotation,
            scale = this.tfmRF.scale,
            components = this.components,
        };
        return save;
    }
}
