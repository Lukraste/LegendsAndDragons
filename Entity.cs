using System;

namespace LegendsAndDragons 
{
    public abstract class Entity
    {
        protected string Name {get; set;}
        protected string Type {get; set;}
        protected string Description {get;set;}
        public int HitPoints {get;set;}
        protected int Armor {get;set;}
        protected bool IsDead{get;set;} 

        public Entity(string name)
        {
            Name = name;
            IsDead = true;
        }
        public virtual void LoseHP(int hitpoints)
        {
            //
        }
    }
}
