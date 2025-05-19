using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    static class Program
    {
   

        [STAThread]
        static void Main(string[] args)
        {
           

            // If run with "--bench", execute the mining benchmark instead of launching the UI
            if (args.Contains("--bench"))
            {
                RunBenchmark();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BlockchainApp());
        }

        /// <summary>
        /// Benchmarks single-threaded vs. multi-threaded mining over several trials.
        /// </summary>
        private static void RunBenchmark()
        {
            const int trials = 5;
            var serialTimes = new List<long>();
            var parallelTimes = new List<long>();

            Console.WriteLine("Starting mining benchmark (Difficulty = {0})", Block.Difficulty);
            Console.WriteLine();

            for (int i = 0; i < trials; i++)
            {
                // ----- Single-threaded mining -----
                var b1 = new BlockUnmined();
                long t1 = Time(() => b1.MineSerial());
                serialTimes.Add(t1);

                // ----- Multi-threaded mining -----
                var b2 = new BlockUnmined();
                long t2 = Time(() => b2.Mine());
                parallelTimes.Add(t2);

                Console.WriteLine(
                    "Trial {0}: Single = {1} ms,  Parallel = {2} ms",
                    i + 1, t1, t2);
            }

            Console.WriteLine();
            Console.WriteLine("Average single-thread: {0:F0} ms", serialTimes.Average());
            Console.WriteLine("Average multi-thread : {0:F0} ms", parallelTimes.Average());
        }

        /// <summary>
        /// Measures how long the given action takes in milliseconds.
        /// </summary>
        private static long Time(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }

    /// <summary>
    /// Helper subclass of Block that does NOT auto-mine in its constructor,
    /// letting us call MineSerial() and Mine() manually.
    /// </summary>
    class BlockUnmined : Block
    {
        public BlockUnmined()
            : base(skipMining: true)
        {
        }

        /// <summary>
        /// Original single-threaded mining loop.
        /// </summary>
        public new void MineSerial()
        {
            string target = new string('0', Difficulty);
            long nonce = 0;
            string hash;
            do
            {
                hash = ComputeHashForNonce(nonce++);
            }
            while (!hash.StartsWith(target));

            Nonce = nonce - 1;
            Hash = hash;
        }
    }
}