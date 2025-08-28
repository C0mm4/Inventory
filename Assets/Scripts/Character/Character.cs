using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field :Header("Status")]
    [field: SerializeField]
    public int Atk { get; private set; }
    [field: SerializeField]
    public int Def { get; private set; }
    [field: SerializeField]
    public int Health {  get; private set; }
    [field: SerializeField]
    public int Critical {  get; private set; }

    [field :Header("Level")]
    [field: SerializeField]
    public int Level {  get; private set; }
    [field: SerializeField]
    public int reqExp {  get; private set; }
    [field: SerializeField]
    public int curExp {  get; private set; }
}
