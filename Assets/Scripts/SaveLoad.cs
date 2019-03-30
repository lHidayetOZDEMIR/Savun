using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class SaveLoad : MonoBehaviour {

    SaveManagement save;
    public float atisGucu, atisHizi, altinMiktari;
    void Start () {
        //atisGucu = FindObjectOfType<Silah>().atisGucu;
        //atisHizi = FindObjectOfType<Silah>().atisHizi;
        //altinMiktari = FindObjectOfType<AltinScript>().altinMiktari;
        save = new SaveManagement();
        Load();
	}
    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" + "Savegame.txt"); 
        save.atisGucu = atisGucu;
        save.atisHizi = atisHizi;
        save.altinMiktari = altinMiktari;
        binary.Serialize(file,save);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.dataPath+ "/" + "Savegame.txt"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open (Application.dataPath + "/" + "Savegame.txt",FileMode.Open);
            save = (SaveManagement)binary.Deserialize(file);
            file.Close();
            atisGucu = save.atisGucu;
            atisHizi = save.atisHizi;
            altinMiktari = save.altinMiktari;
        }
    }
    [Serializable]
    public class SaveManagement
    {
        public float atisGucu, atisHizi,altinMiktari;
    }

}
