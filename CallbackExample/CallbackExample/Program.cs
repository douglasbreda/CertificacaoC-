using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackExample
{
    /// <summary>
    /// Exemplo retirado da questão:
    /// You are developing an application that includes a class named BookTracker for tracking
    /// library books.
    /// You need to add a user to the BookTracker instance. What should you do?
    /// 
    /// </summary>
    class Program
    {

        public delegate void AddBookCallback( int i );

        public class BookTracker
        {
            List<Book> books = new List<Book>();
            public void AddBook( string name, AddBookCallback callback )
            {
                books.Add( new Book( name ) );
                callback( books.Count );
            }
        }


        public class Runner
        {
            BookTracker tracker = new BookTracker();

            public void Add( string name )
            {
                tracker.AddBook( name, delegate ( int i )
                {
                    Console.WriteLine( $"Book: {name} Number: {i}" );
                } );
            }
        }


        static void Main( string[] args )
        {
            Runner oRunner = new Runner();

            oRunner.Add( "Test Callback 1ed." );
            oRunner.Add( "Test Callback 2ed." );
            oRunner.Add( "Test Callback 3ed." );
            oRunner.Add( "Test Callback 4ed." );

            Console.ReadKey();
        }
    }
}
