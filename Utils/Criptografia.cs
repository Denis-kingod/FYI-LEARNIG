namespace tcc_dbfyi.Utils
{
    public class Criptografia
    {
        public static string ConstruirHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Verificar(string senha, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senha, senhaBanco);
        }
    }
}
