using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field :Header("Status")]
    [field: SerializeField]
    public string Name {  get; private set; }

    [field: SerializeField]
    public List<Status> Statuses { get; private set; }

    [field :Header("Level")]
    [field: SerializeField]
    public int Level {  get; private set; }
    [field: SerializeField]
    public int reqExp {  get; private set; }
    [field: SerializeField]
    public int curExp {  get; private set; }
}


[Serializable]
public class Status
{
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public int Value {  get; private set; }
    [field: SerializeField]
    public string SpritePath {  get; private set; }
}

