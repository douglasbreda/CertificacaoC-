using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceCountersExample
{
    /// <summary>
    /// Exemplo retirado da questão:
    /// You are developing a method named CreateCounters that will create.
    /// You need to ensure that Counter2 is available for use in Windows Performance Monitor(PerfMon)
    /// </summary>
    class Program
    {
        static void Main( string[] args )
        {
            CreateCounters();
            Console.ReadKey();
        }

        public static void CreateCounters()
        {
            if ( !PerformanceCounterCategory.Exists( "Contoso" ) )
            {
                var counters = new CounterCreationDataCollection();

                var ccdCounter1 = new CounterCreationData
                {
                    CounterName = "Counter1",
                    CounterType = PerformanceCounterType.AverageTimer32
                };

                counters.Add( ccdCounter1 );

                var ccdCounter2 = new CounterCreationData
                {
                    CounterName = "Counter2",
                    CounterType = PerformanceCounterType.AverageBase
                };

                counters.Add( ccdCounter2 );
                PerformanceCounterCategory.Create( "Contoso", "Help string", PerformanceCounterCategoryType.MultiInstance, counters );

            }
        }

    }
}
