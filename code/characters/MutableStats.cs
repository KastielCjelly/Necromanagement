namespace Necromanagement.Characters {
    public class MutableStats: Stats {
        private Stats AsImmutable => this;
        public void SetSpeed(int value) => Speed = value;
        public void SetStrength(int value) => Strength = value;
        public void SetVitality(int value) => Vitality = value;
        public void SetIntelligence(int value) => Intelligence = value;
        
    }
}