using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

/// <summary>
/// Базовый класс для объектов окружения на сцене
/// </summary>
public abstract class SceneModelScript : MyBaseObjectScene
{
    /// <summary>
    /// Добавление компонента Rigidbody
    /// </summary>
    public void AddRigidbody()
    {
        if (GetRigidBody == null)
            _rigidBody = gameObject.AddComponent<Rigidbody>();
    }

    /// <summary>
    /// Установка состояния физики (вкл/выкл)
    /// </summary>
    /// <param name="value">Требуемое состояние физики</param>
    public void SetRigidbody(bool value)
    {
        if (_rigidBody != null)
            _rigidBody.isKinematic = !value;
    }

    /// <summary>
    /// "Заморозка" движения/вращения объекта.
    /// </summary>
    public virtual void FreezeRigidbody()
    {
        if (_rigidBody != null)
            _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
