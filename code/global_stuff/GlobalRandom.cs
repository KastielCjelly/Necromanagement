using System;

namespace Necromanagement.GlobalStuff {
    public static class GlobalRandom {
        public static Random Instance => _instance ?? (_instance = new Random());
        private static Random _instance;
    }
}