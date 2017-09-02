//TinyURL is a URL shortening service where you enter a URL 
//such as https://leetcode.com/problems/design-tinyurl and it returns a short URL such as http://tinyurl.com/4e9iAk.
//Design the encode and decode methods for the TinyURL service. There is no restriction on how your encode/decode algorithm 
//should work. You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded to the original URL.
//算法思路：随机生成随便几位数字字母组合作为键值对应给出的URL添加进哈希表，返回键值达到缩短URL的目的；查找并返回键所对应的唯一值即展开原URL

public class Codec {

    // Encodes a URL to a shortened URL
    
    public Hashtable ht = new Hashtable();
    
    private static char[] constant = {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
    
    public static string GenerateRandomNumber(int Length) {
        System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
        Random rd = new Random();
        for (int i = 0; i < Length; i++) {
            newRandom.Append(constant[rd.Next(62)]);
        }
        return newRandom.ToString();
    }
    
    public string encode(string longUrl) {
        string randomNum = GenerateRandomNumber(6);
        ht.Add(randomNum, longUrl);
        return "http://tinyurl.com/" + randomNum;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        string subUrl = shortUrl.Substring(19);
        string oriUrl = (string)ht[subUrl];
        return oriUrl;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
