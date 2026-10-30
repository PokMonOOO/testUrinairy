
namespace Pkmn
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>

    public enum EFFECT { NOTHING, PRIO }

    public class Equipment
    {
        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed, EFFECT effect = EFFECT.NOTHING)
        {
            BonusHealth = bonusHealth;
            BonusAttack = bonusAttack;
            BonusDefense = bonusDefense;
            BonusSpeed = bonusSpeed;

            BonusEffect = effect;
            EffectUsed = false;
        }

        public int BonusHealth { get; protected set; }
        public int BonusAttack { get; protected set; }
        public int BonusDefense { get; protected set; }
        public int BonusSpeed { get; protected set; }

        public EFFECT BonusEffect { get; protected set; }
        public bool EffectUsed { get; protected set; }


        public void UseEffect() => EffectUsed = false;

    }
}
