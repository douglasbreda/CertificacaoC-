using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldExample
{
    /// <summary>
    /// Exemplo extraído da documentação da Microsoft
    /// </summary>
    class Program
    {
        static void Main( string[] args )
        {
            foreach ( int item in Power( 2, 8 ) )
            {
                Console.Write( $"{item} " );
            }

            Console.ReadKey();
        }

        public static IEnumerable<int> Power(int number, int exponent )
        {
            int result = 1;

            for ( int i = 0; i < exponent; i++ )
            {
                result = result * number;
                yield return result;
            }
        }
    }
}
