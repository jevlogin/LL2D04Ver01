using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 51)]
    public sealed class EnemyData : ScriptableObject
    {
        #region Fields

        [Header("Настройки свойств противников."), Space(20)] public EnemyStruct EnemyStruct;
        [Header("Содержит компоненты. Заполняется из кода. НЕ ТРОГАТЬ!"), Space(20)] public EnemyComponents EnemyComponents;
        [Header("Содержит всевозможные настройки для противника."), Space(20)] public EnemySettingsData EnemySettingsData;

        #endregion
    }
}
