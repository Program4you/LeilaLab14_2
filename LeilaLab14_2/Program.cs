using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LeilaLab14_2 {
    class Program {
        static List<long> primes = new List<long>();

        static long gcd(long a, long b) {
            if (b == 0)
                return a;

            return gcd(b, a % b);
        }

        static long modPow(long a, long n, long mod) {
            if (n == 0)
                return 1;

            if (n % 2 == 1)
                return (modPow(a, n - 1, mod) * a) % mod;

            long b = modPow(a, n / 2, mod);
            return (b * b) % mod;
        }

        static bool prime(long n) {
            for (long x = primes[primes.Count - 1]; x < n; x++) {
                bool isPrime = true;

                for (int i = 0; i < primes.Count && isPrime; i++)
                    if (x % primes[i] == 0)
                        isPrime = false;

                if (isPrime)
                    primes.Add(x);
            }

            return primes[primes.Count - 1] == n;
        }

        static bool test(long n) {
            for (long a = 2; a < n; a++) {
                if (gcd(n, a) != 1)
                    continue;

                if (prime(a))
                    continue;

                if (modPow(a, n - 1, n) != 1)
                    return false;
            }

            return true;
        }

        static void Main(string[] args) {
            primes.Add(2);

            StreamWriter sr = new StreamWriter("output_14_2.txt");
            
            for (long n = 1; n < 10000; n++) {
                if (test(n))
                    sr.WriteLine(n);
            }

            sr.Close();
        }
    }
}
