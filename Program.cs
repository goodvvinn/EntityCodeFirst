using System;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
               await new EntitiesDataModify(context).EntityUpdateAsync();
            }
        }
    }
}
