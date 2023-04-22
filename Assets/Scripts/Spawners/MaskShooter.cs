using UnityEngine;

public class MaskShooter : ClickSpawner
{
    // [SerializeField] NumberField scoreField;
    public static int score;
    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();
        return newObject;
    }
}
