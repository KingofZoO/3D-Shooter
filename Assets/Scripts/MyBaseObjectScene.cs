using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNameSpace
{
    /// <summary>
    /// Базовый класс объектов
    /// </summary>
    public abstract class MyBaseObjectScene : MonoBehaviour
    {
        protected int _layer;
        protected Color _color;
        protected Material _material;
        protected Transform _transform;
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected Rigidbody _rigidBody;
        protected string _name;
        protected bool _isVisible;

        #region UnityFunctions
        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;

            if (GetComponent<Renderer>() != null)
                _material = GetComponent<Renderer>().material;

            if (GetComponent<Rigidbody>() != null)
                _rigidBody = GetComponent<Rigidbody>();

            _transform = _instanceObject.transform;
        }
        #endregion

        #region Access methods

        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _instanceObject.name = _name;
            }
        }

        /// <summary>
        /// Слой объекта
        /// </summary>
        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
                _instanceObject.layer = _layer;
            }
        }

        /// <summary>
        /// Цвет материала
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                _material.color = _color;
            }
        }

        /// <summary>
        /// Материал
        /// </summary>
        public Material GetMaterial
        {
            get { return _material; }
        }

        /// <summary>
        /// Позиция объекта
        /// </summary>
        public Vector3 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _transform.localPosition = _position;
            }
        }

        /// <summary>
        /// Масштабирование объекта
        /// </summary>
        public Vector3 Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                _transform.localScale = _scale;
            }
        }

        /// <summary>
        /// Поворот объекта
        /// </summary>
        public Quaternion Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                _transform.localRotation = _rotation;
            }
        }

        /// <summary>
        /// Физическое тело объекта
        /// </summary>
        public Rigidbody GetRigidBody
        {
            get { return _rigidBody; }
        }

        /// <summary>
        /// Ссылка на gameobject
        /// </summary>
        public GameObject GetInstanceObject
        {
            get { return _instanceObject; }
        }

        /// <summary>
        /// Скрывает или показывает объект
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                if (_instanceObject.GetComponent<MeshRenderer>() != null)
                {
                    _instanceObject.GetComponent<MeshRenderer>().enabled = _isVisible;
                }
                if (_instanceObject.GetComponent<SkinnedMeshRenderer>() != null)
                {
                    _instanceObject.GetComponent<SkinnedMeshRenderer>().enabled = _isVisible;
                }
                if (_instanceObject.GetComponent<Collider>() != null)
                {
                    _instanceObject.GetComponent<Collider>().enabled = _isVisible;
                }
            }
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Устанавливает слой. Рекурсивно
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="lvl">Слой</param>
        private void AskLayer(Transform obj, int lvl)
        {
            obj.gameObject.layer = lvl;
            if (obj.childCount > 0)
            {
                foreach (Transform child in obj)
                {
                    AskLayer(child, lvl);
                }
            }
        }

        private void AskColor(Transform obj, Color lvl)
        {

        }

        #endregion
    }
}