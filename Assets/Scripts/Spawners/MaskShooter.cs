using UnityEngine;

public class MaskShooter : ClickSpawner
{
    // [SerializeField] NumberField scoreField;

    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();
        return newObject;
    }
}
