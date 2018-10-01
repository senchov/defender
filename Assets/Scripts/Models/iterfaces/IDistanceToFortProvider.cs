namespace Assets.Scripts.Models
{
    interface IDistanceToFortProvider
    {
        float GetMinDistanceToFort(string id);
        float GetMinDistanceToGetDamage (string id);
    }
}
