using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class sGameController : MonoBehaviour
{
    public string saveFilePath { get => $"{Application.persistentDataPath}/save.json"; }
    public List<ObjectSaveDTO> ObjectSaveList = new List<ObjectSaveDTO>();
    public List<BlocoClass> objects = new List<BlocoClass>();

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerSaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerSave();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateObjectCube();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            CreateObjectCapsule();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateObjectCylinder();
        }
    }

    private void CreateObjectCube() 
    {
        ObjectSaveDTO saveDTO = new ObjectSaveDTO();

        for(int i = 0; i < 2; i++)
        {
            var R = UnityEngine.Random.Range(0f, 1f);
            var G = UnityEngine.Random.Range(0f, 1f);
            var B = UnityEngine.Random.Range(0f, 1f);
            var colorr = new Color(R, G, B);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-4.0f, 4.0f), UnityEngine.Random.Range(-2.0f, 2.0f), 0);
            Quaternion rotation = new Quaternion(UnityEngine.Random.Range(0f, 4.0f), UnityEngine.Random.Range(0f, 2.0f), 0, 0);
            Vector3 scale = new Vector3(UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f));

           
            
            BlocoClass go = new BlocoClass(ObjectType.WTypeOb(ObjectType.Aux.Cube), Collider.Collider, colorr, position, rotation, scale);
            objects.Add(go);
        }
    }

    private void CreateObjectCapsule()  
    {
        ObjectSaveDTO saveDTO = new ObjectSaveDTO();

        for (int i = 0; i < 2; i++)
        {
            var R = UnityEngine.Random.Range(0f, 1f);
            var G = UnityEngine.Random.Range(0f, 1f);
            var B = UnityEngine.Random.Range(0f, 1f);
            var colorr = new Color(R, G, B);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-4.0f, 4.0f), UnityEngine.Random.Range(-2.0f, 2.0f), 0);
            Quaternion rotation = new Quaternion(UnityEngine.Random.Range(0f, 4.0f), UnityEngine.Random.Range(0f, 2.0f), 0, 0);
            Vector3 scale = new Vector3(UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f));

           

            BlocoClass go = new BlocoClass(ObjectType.WTypeOb(ObjectType.Aux.Capsule), Collider.Collider, colorr, position, rotation, scale);
            objects.Add(go);
        }
    }

    private void CreateObjectCylinder() 
    {
        ObjectSaveDTO saveDTO = new ObjectSaveDTO();

        for (int i = 0; i < 2; i++)
        {
            var R = UnityEngine.Random.Range(0f, 1f);
            var G = UnityEngine.Random.Range(0f, 1f);
            var B = UnityEngine.Random.Range(0f, 1f);
            var colorr = new Color(R, G, B);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-4.0f, 4.0f), UnityEngine.Random.Range(-2.0f, 2.0f), 0);
            Quaternion rotation = new Quaternion(UnityEngine.Random.Range(0f, 4.0f), UnityEngine.Random.Range(0f, 2.0f), 0, 0);
            Vector3 scale = new Vector3(UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f));

            

            BlocoClass go = new BlocoClass(ObjectType.WTypeOb(ObjectType.Aux.Cylinder), Collider.Collider, colorr, position, rotation, scale);
            objects.Add(go);
        }
    }

    private void PlayerSaveToJson()
    {
        
        foreach (BlocoClass go in objects)
        {
            ObjectSaveList.Add(go.GetSaveData());
        }
 
        var saves = new ObjectSave()
        {
            Saves = ObjectSaveList.ToArray()
        };
        var json = JsonUtility.ToJson(saves, true);
        Debug.Log(json);

        Debug.Log(saveFilePath);
        File.WriteAllText(saveFilePath, json);
    }

    private void LoadPlayerSave()  
    {
        var jsonText = File.ReadAllText(saveFilePath);
        Debug.Log(jsonText);

        var saveData = JsonUtility.FromJson<ObjectSave>(jsonText);    
        ObjectSaveList = new List<ObjectSaveDTO>();
        ObjectSaveList.AddRange(saveData.Saves);

        
        int aux = 0;
        foreach (var objct in ObjectSaveList)
        {
            BlocoClass go2 = new BlocoClass(ObjectSaveList[aux].obTypeString, ObjectSaveList[aux].clld, ObjectSaveList[aux].color, ObjectSaveList[aux].position, ObjectSaveList[aux].rotation, ObjectSaveList[aux].scale);
            objects.Add(go2);
            aux++;
        }
    }
}
