namespace CA.Domain.DbInfo
{
    public class DbInfo : IDbInfo
    {
        public DbInfo(string connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public string ConnectionStrings { get; }
    }
}
