namespace Necromanagement.Characters {
    public abstract class Stats {
        public int Speed { get; protected set; }
        public int Strength { get; protected set; }
        public int Intelligence { get; protected set; }
        public int Vitality { get; protected set; }

        public MutableStats Copy() {
            var result = new MutableStats();
            result.SetSpeed(Speed);
            result.SetStrength(Strength);
            result.SetVitality(Vitality);
            result.SetIntelligence(Intelligence);
            return result;
        }
    }
}