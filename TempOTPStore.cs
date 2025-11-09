using System.Collections.Generic;

namespace LOGIN
{
    public static class TempOTPStore
    {
        private static Dictionary<string, string> store = new Dictionary<string, string>();
        public static void Add(string email, string otp)
        {
            if (store.ContainsKey(email))
                store[email] = otp;
            else
                store.Add(email, otp);
        }
        public static bool IsValid(string email, string otp)
        {
            return store.ContainsKey(email) && store[email] == otp;
        }
        public static void Remove(string email)
        {
            if (store.ContainsKey(email))
                store.Remove(email);
        }
    }
}
