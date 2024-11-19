using System.Text;

namespace Services.Common
{
    public class Security
    {
        public string EncryptedValue(string input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    int inputLen = input.Length;
                    int randKey = new Random().Next(1, 10);

                    var inputChr = new int[inputLen];
                    for (int i = 0; i < inputLen; i++)
                    {
                        inputChr[i] = input[i] - randKey;
                    }

                    var sb = new StringBuilder();
                    foreach (var i in inputChr)
                    {
                        sb.Append(i);
                        sb.Append('a');
                    }

                    sb.Append((char)(randKey + 50));

                    return sb.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string DecryptedValue(string input)
        {
            try
            {
                string[] inputArr = input.Split('a');
                int inputLen = inputArr.Length - 1;

                int randKey = (input[input.Length - 1] - 50);

                List<int> inputChr = new List<int>();
                for (int i = 0; i < inputLen; i++)
                {
                    if (int.TryParse(inputArr[i], out int charCode))
                    {
                        inputChr.Add(charCode + randKey);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }

                return new string(inputChr.Select(c => (char)c).ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
