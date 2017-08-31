namespace Shopping {
    class clsDiversos {
        public static string TiraAcento(string letra) {
            if ("BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz".Contains(letra))
                return letra;
            if ("ÀÁÂÃÄÅàáâãäå".Contains(letra))
                return "A";
            if ("éèëêÉÈËÊ".Contains(letra))
                return "E";
            if ("ÌÍÎÏìíîï".Contains(letra))
                return "I";
            if ("ÒÓÔÕÖØòóôõöø".Contains(letra))
                return "O";
            return "ÙÚÛÜùúûüµ".Contains(letra) ? "U" : letra;
        }
    }
}
