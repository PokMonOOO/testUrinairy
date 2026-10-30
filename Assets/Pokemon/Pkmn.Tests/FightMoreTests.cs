using System;
using NUnit.Framework;

namespace Pkmn.Tests
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        [Test]
        public void CharacterNegativeHeal()
        {
            var c = new Character(100, 50, 30, 20, TYPE.NORMAL);

            Assert.Throws<ArgumentException>(() =>
            {
                c.Heal(-98989);
            });

            Assert.That(c.CurrentHealth, Is.EqualTo(c.MaxHealth));
        }
        [Test]
        public void CharacterHeal()
        {
            var c = new Character(100, 50, 30, 20, TYPE.NORMAL);
            var e = new Equipment(100, 90, 70, 12);

            c.Equip(e);
            c.Heal(98989);

            Assert.That(c.CurrentHealth, Is.EqualTo(c.MaxHealth));
        }
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        [Test]
        public void CharacterIncrementOrDrecrementMaxHealth()
        {
            var c = new Character(100, 50, 30, 20, TYPE.NORMAL);

            // ++
            c.IncrementOrDecrementMaxHealth(98989);
            Assert.That(c.MaxHealth, Is.EqualTo(99089));
            // --
            c.IncrementOrDecrementMaxHealth(-100);
            Assert.That(c.MaxHealth, Is.EqualTo(98989));
            // less than _baseHealth
            Assert.Throws<ArgumentException>(() =>
            {
                c.IncrementOrDecrementMaxHealth(-98989);
                c.IncrementOrDecrementMaxHealth(-95);
            });
        }
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        [Test]
        public void PrioEquipementUnique()
        {
            var axoloto = new Character(100, 50, 30, 20, TYPE.NORMAL);
            var e = new Equipment(0, 50, 50, 30, EFFECT.PRIO);
            axoloto.Equip(e);
            var bidoof = new Character(100, 50, 30, 98989, TYPE.NORMAL);
            Punch p = new Punch();
            MegaPunch mp = new MegaPunch();
            Fight f = new Fight(axoloto, bidoof);

            f.ExecuteTurn(mp, p);
            Assert.That(axoloto.IsAlive, Is.EqualTo(true));
            Assert.That(bidoof.IsAlive, Is.EqualTo(false));
        }
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
        // si on selectionne une attack qui a 0 PP on inflige 0

        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
        // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
        // de ces anciens TU pour ta nouvelle situation.

    }
}
