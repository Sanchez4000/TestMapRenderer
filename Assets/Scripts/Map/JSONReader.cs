using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Map
{
    static class JSONReader
    {
        public static string ReadJsonText(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return "";
        }
        public static List<TileData> ReadMapDataFromJson(string json)
        {
            int startDataIndex = json.IndexOf('[');
            int dataLength = json.IndexOf(']') - (startDataIndex + 1);
            string dataOnly = json.Substring(startDataIndex, dataLength);

            bool findData = true;
            List<TileData> allDatas = new List<TileData>();

            while (findData)
            {
                startDataIndex = dataOnly.IndexOf('{');
                dataLength = dataOnly.IndexOf('}') - startDataIndex + 1;

                string jsonTileData = "";
                try
                {
                    jsonTileData = dataOnly.Substring(startDataIndex, dataLength);
                }
                catch (ArgumentOutOfRangeException)
                {
                    jsonTileData = "";
                }
                findData = jsonTileData == "" ? false : true;

                if (findData)
                {             
                    TileData data = JsonUtility.FromJson<TileData>(jsonTileData);
                    allDatas.Add(data);

                    dataOnly = dataOnly.Remove(startDataIndex, dataLength);
                } 
            }

            return allDatas;
        }
    }
}
