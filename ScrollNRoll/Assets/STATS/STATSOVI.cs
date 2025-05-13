using UnityEngine;

[CreateAssetMenu(fileName = "STATS", menuName = "STATS/NOVI STATS/Create New")]
public class STATSOVI : ScriptableObject
{
    [field: SerializeField] public float TimeToBeatRace { get; private set; }
    [field: SerializeField] public int NumberOfLaps { get; private set; }
    [field: SerializeField] public float StandingEnemyDmg { get; private set; }
    [field: SerializeField] public float FlyingEnemyDmg { get; private set; }
    [field: SerializeField] public int AmmoAddedOnBuy { get; private set; }
    [field: SerializeField] public int AmmoOnStart { get; private set; }
    [field: SerializeField] public float HitsRequiredToKill { get; private set; }
    [field: SerializeField] public float DopamineAddedOnKill { get; private set; }
    [field: SerializeField] public float DopamineAddedOnAmmoBuy { get; private set; }
    [field: SerializeField] public float DopamineMax { get; private set; }
    [field: SerializeField] public int PercentChanceForAdToAppear { get; private set; }

}
