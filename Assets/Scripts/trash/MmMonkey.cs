//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CodeMonkey;
//using CodeMonkey.Utils;
//using System.IO;

//public class MmMonkey : MonoBehaviour
//{
//    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

//    [SerializeField] private GameObject unitgameObject;
//    private IUnit unit;


//    private void Awake()
//    {
//        unit = unitgameObject.GetComponent<IUnit>();

//    }


//    private void Update()
//    {
    
    
//    }


//    private void Save()
//    {

//        Vector3 playerPosition = unit.GetPosition();
//        int puntos = unit.Puntos();

//        string[] contents = new string[]
//        {
//                ""+puntos,
//                ""+playerPosition.x,
//                ""+playerPosition.y

//        };


//        string saveString = string.Join(SAVE_SEPARATOR, contents);
//        File.WriteAllText(Application.dataPath + "/save.txt", saveString);

//        CMDebug.TextPopupMouse("Saved"!);



//    }
















//}
