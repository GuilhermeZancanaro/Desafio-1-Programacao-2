using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectType
{
    public enum Aux {Cube, Capsule, Cylinder};
    
    public Aux get;
    public GameObject go;

    static public ObjectType WTypeOb(Aux aux)
    {
        switch (aux)
        {
            case Aux.Cube:
                var cube = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cube), get = Aux.Cube };
                return cube;
            case Aux.Capsule:
                var capsule = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Capsule), get = Aux.Capsule };
                return capsule;
            case Aux.Cylinder:
                var cylinder = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cylinder), get = Aux.Cylinder };
                return cylinder;
            default:
                Debug.Log("TIPO DE OBJETO NÃO EXISTE!!!. Opções: GameObject, Cube, Capsule, Sphere, Cylinder, Plane, Quad");
                break;
        }
        return new ObjectType() { };
    }

    static public ObjectType WTypeOb(string aux)
    {
        switch (aux)
        {
            case "Cube":
                var cube = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cube), get = Aux.Cube };
                return cube;
            case "Capsule":
                var capsule = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Capsule), get = Aux.Capsule };
                return capsule;
            case "Cylinder":
                var cylinder = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cylinder), get = Aux.Cylinder };
                return cylinder;
            default:
                Debug.Log("TIPO DE OBJETO NÃO EXISTE!!!. Opções:Cube, Capsule, Sphere, Cylinder");
                break;
        }
        return new ObjectType() { };
    }
}
