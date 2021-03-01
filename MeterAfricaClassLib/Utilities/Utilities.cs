using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeterAfricaClassLibrary.Utilities
{
    public static class Utilities
    {
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreReadOnlyProperties = false,
            IgnoreNullValues = false
        };

        public static string MoneyFormatter(decimal? Amount, bool addSign = false)
        {
            string formattedAmnt = Amount < 0 || Amount == null ? "0.00" : Convert.ToDecimal(Amount).ToString("#,##0.00");
            return addSign ? formattedAmnt : $"&#x20A6; {formattedAmnt}";
        }

        public static string Ref(int lenght = 10, bool includeTimeStamp = false, bool alphabetOnly = false, bool numbersOnly = false)
        {

            if (numbersOnly && alphabetOnly) { return ""; }
            var reference = GenerateGuid();
            reference = alphabetOnly || numbersOnly ? $"{reference}{GenerateGuid()}{GenerateGuid()}" : reference;
            reference = alphabetOnly ? Regex.Replace(reference, @"[\d-]", string.Empty) : reference;
            reference = numbersOnly ? Regex.Replace(reference, "[^0-9.]", string.Empty) : reference;
            reference = reference.Remove(lenght).ToUpper();
            return includeTimeStamp ? $"{DateTime.Now:ssmmhhddMMyy}{reference}" : reference;
        }

        private static string GenerateGuid()
        {
            return $"{Guid.NewGuid().ToString().Replace("-", "")}";
        }

        public static T DeserializeJson<T>(string input)
        {
            return JsonSerializer.Deserialize<T>(input, jsonOptions);
        }

        public static string SerializeToJson(object input)
        {
            return JsonSerializer.Serialize(input, jsonOptions);
        }

        public static async Task<T> DeserializeRequestAsync<T>(HttpResponseMessage response)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<T>(contentStream, jsonOptions);
            return result;
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new MailAddress(email);
                if (addr.Address != email) return false;

                var split = email.Split('@')[1];
                if (!split.Contains('.')) return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string TrimAllSpace(this string value)
        {
            return Regex.Replace(value, @"\s+", "");
        }

        public static string TrimAndLower(this string value)
        {
            return value.Trim().ToLower();
        }

        public static string TrimAndUpper(this string value)
        {
            return value.Trim().ToUpper();
        }

        public static string GetSHA512Hash(string inputString)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] byteArray = sha512.ComputeHash(bytes);

            var stringResult = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++)
            {
                stringResult.Append(byteArray[i].ToString("X2"));
            }
            return stringResult.ToString();
        }

        public static string GetSHA1Hash(string inputString, string privateKey)
        {
            var encoding = new ASCIIEncoding();
            byte[] privateKeyByte = encoding.GetBytes(privateKey);
            byte[] messageBytes = encoding.GetBytes(inputString);
            using var hmacsha1 = new HMACSHA1(privateKeyByte);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            return Convert.ToBase64String(hashmessage);
        }

        public static string GetHash(string inputString, string privateKey)
        {
            var encoding = new ASCIIEncoding();
            byte[] inputBytes = encoding.GetBytes(inputString);
            byte[] keyBytes = encoding.GetBytes(privateKey);
            byte[] hashBytes;

            using (HMACSHA1 hash = new HMACSHA1(keyBytes))
                hashBytes = hash.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public static void Forget(this Task task)
        {
            if (!task.IsCompleted || task.IsFaulted)
            {
                _ = ForgetAwaited(task);
            }

            async static Task ForgetAwaited(Task task)
            {
                try { await task.ConfigureAwait(false); }
                catch {/*Nothing to do here*/ }
            }
        }

        public static string Base64Encoder(this string text)
        {
            byte[] encodedBytes = Encoding.ASCII.GetBytes(text);
            // byte[] encodedBytes = Encoding.Unicode.GetBytes(text);
            var data = Convert.ToBase64String(encodedBytes);
            return data;
        }

        public static bool IsHasCharacter(this string input)
        {
            return input.Any(x => char.IsLetter(x));
        }
    }
}
