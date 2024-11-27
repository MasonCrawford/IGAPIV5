using System.Text;
using PCLCrypto;

namespace IgClient.Security;

public class Rsa
{
    public Rsa(byte[] key, bool intermediateConvertToBase64BeforeEncryption = false, bool isPrivateKey = false)
    {
        try
        {
            var rsa = WinRTCrypto.AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithm.RsaPkcs1);
            IntermediateConvertToBase64BeforeEncryption = intermediateConvertToBase64BeforeEncryption;
            CanDecrypt = isPrivateKey;


            if (isPrivateKey)
                _key = rsa.ImportKeyPair(key);
            else
                _key = rsa.ImportPublicKey(key);
        }
        catch (Exception ex)
        {
            var exception = ex.Message;
        }
    }

    private ICryptographicKey _key { get; }

    protected bool IntermediateConvertToBase64BeforeEncryption { get; set; }

    protected bool CanDecrypt { get; set; }

    public byte[] RsaEncrypt(string data)
    {
        //IBuffer databuf = CryptographicBuffer.ConvertStringToBinary(data, BinaryStringEncoding.Utf8);
        var databuf = Encoding.UTF8.GetBytes(data);

        if (IntermediateConvertToBase64BeforeEncryption)
            //convert byte array to base 64 and then reencode it to UTF8, which in this case should be == ascii.
            //databuf = CryptographicBuffer.ConvertStringToBinary(Convert.ToBase64String(databuf.ToArray()), BinaryStringEncoding.Utf8);			   
            databuf = Encoding.UTF8.GetBytes(Convert.ToBase64String(databuf));
        return WinRTCrypto.CryptographicEngine.Encrypt(_key, databuf).ToArray();
    }

    public string RsaDecrypt(byte[] encrypted)
    {
        //
        if (!CanDecrypt) throw new Exception("Unable to Decrypt, class was only initalised with a public key");

        var data = WinRTCrypto.CryptographicEngine.Decrypt(_key, encrypted);

        var encoding = new UTF8Encoding();

        if (IntermediateConvertToBase64BeforeEncryption)
            data = Convert.FromBase64String(encoding.GetString(data, 0,
                data.Length)); // WinRTCrypto.CryptographicBuffer.ConvertBinaryToString(Encoding.UTF8, data));                           
        return encoding.GetString(data, 0, data.Length);
    }
}