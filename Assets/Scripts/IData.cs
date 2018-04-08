using UnityEngine;
using System.Collections.Generic;

namespace MyNameSpace.Data
{
	public interface IData
	{
		void Save(SavedData data);
		SavedData Load();
		void SetPath(string path);
        string GetPath();
	}

	public struct SavedData
	{
		public float Hp;
        public Vector3 Position;
        public Quaternion Rotation;
        public List<int> CurrentAmmo;
        public List<int> AmmoSize;

        public Vector3 BotPosition;
        public Quaternion BotRotation;
	}
}