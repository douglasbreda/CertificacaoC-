using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarrierGasStationExample
{
    /// <summary>
    /// Exemplo extraído de:
    /// http://geekswithblogs.net/jolson/archive/2009/02/09/an-intro-to-barrier.aspx
    /// Neste exemplo, é possível notar que os objetos não esperam todos chegar para sair
    /// Essa é a diferença de usar e não usar a classe Barrier
     
    /// </summary>
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "1 - Exemplo sem barrier" );
            Console.WriteLine( "2 - Exemplo com barrier" );

            int option = Convert.ToInt32( Console.ReadLine() );

            switch ( option )
            {
                case 1:
                    GasStationWithoutBarrier();
                    break;
                case 2:
                    GasStationWithBarrier();
                    break;
            }
            
        }

        #region [Exemplo sem o uso do Barrier]

 
        public static void GasStationWithoutBarrier()
        {
            var charlie = new Thread( () =>
            {
                DriveToSeattleWithoutBarrier( "Charlie", TimeSpan.FromSeconds( 1 ) );
            } );
            charlie.Start();

            var mac = new Thread( () => {
                DriveToSeattleWithoutBarrier( "Mac", TimeSpan.FromSeconds( 2 ) );
            } );
            mac.Start();

            var dennis = new Thread( () => {
                DriveToSeattleWithoutBarrier( "Dennis", TimeSpan.FromSeconds( 3 ) );
            } );
            dennis.Start();

            charlie.Join();
            mac.Join();
            dennis.Join();

            Console.ReadKey();
        }

        public static void DriveToSeattleWithoutBarrier( string name, TimeSpan timeToGasStation )
        {
            // Drive to gas station
            Console.WriteLine( "[{0}] Leaving House", name );
            Thread.Sleep( timeToGasStation );
            Console.WriteLine( "[{0}] Arrived at Gas Station", name );

            // Need to sync here

            // Perform some more work
            Console.WriteLine( "[{0}] Leaving for Seattle", name );
        }

        #endregion

        #region [Exemplo com o uso do Barrier]

        static Barrier sync;


        public static void GasStationWithBarrier()
        {
            sync = new Barrier( participantCount: 3 );

            var charlie = new Thread( () => {
                DriveToSeattle( "Charlie", TimeSpan.FromSeconds( 1 ) );
             } );
            charlie.Start();

            var mac = new Thread( () => {
                DriveToSeattle( "Mac", TimeSpan.FromSeconds( 2 ) );
             } );
            mac.Start();

            var dennis = new Thread( () => {
                DriveToSeattle( "Dennis", TimeSpan.FromSeconds( 3 ) );
             } );
            dennis.Start();

            charlie.Join();
            mac.Join();
            dennis.Join();

            Console.ReadKey();
        }

        public static void DriveToSeattle( string name, TimeSpan timeToGasStation )
        {
            // Drive to gas station
            Console.WriteLine( "[{0}] Leaving House", name );
            Thread.Sleep( timeToGasStation );
            Console.WriteLine( "[{0}] Arrived at Gas Station", name );

            // Need to sync here
            sync.SignalAndWait();

            // Perform some more work
            Console.WriteLine( "[{0}] Leaving for Seattle", name );
        }

        #endregion
    }
}
