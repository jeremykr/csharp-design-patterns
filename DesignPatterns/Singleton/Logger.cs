using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/* -- Singleton --
 * 
 * The Singleton design pattern is especially useful when
 * only one instance of a class should exist at any given time.
 * 
 * This is accomplished by hiding the constructor, and instead
 * exposing a static method that returns an instance of the
 * already-instantiated object. The only time the constructor
 * is actually called is when GetInstance() is called for the
 * first time.
*/
namespace DesignPatterns.Singleton {

    class Logger {

        static Logger instance = null;

        public int LogCount { get; private set; }

        private Logger() {
            LogCount = 0;
        }

        public static Logger GetInstance() {
            if (instance == null) {
                instance = new Logger();
            }
            return instance;
        }

        public void Log(string message) {
            LogCount++;
            Console.WriteLine(string.Format(
                "[{0}] {1}",
                DateTime.Now.ToString(),
                message
            ));
        }
    }

    class LoggerTest {

        [TestMethod]
        public static void Run() {
            Console.WriteLine("Fetching Logger instance...");
            Logger logger1 = Logger.GetInstance();
            logger1.Log("This is a log message.");

            Console.WriteLine("Fetching Logger instance again...");
            Logger logger2 = Logger.GetInstance();
            logger2.Log("This is another log message.");

            try {
                Assert.AreEqual(logger1, logger2);
            } catch (AssertFailedException e) {
                Console.WriteLine(e.Message);
            }
            
            Debug.WriteLine(string.Format(
                "Total messages logged: {0}",
                logger2.LogCount
            ));

            try {
                Assert.AreEqual(logger2.LogCount, 2);
            } catch (AssertFailedException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
