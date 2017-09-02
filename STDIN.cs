//读取int
int n = Convert.ToInt32(Console.ReadLine());

//将string类型的标准输入转化为int[]类型数组读取
int[] s = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);

//将int[]类型数组转化为string[]类型数组
string[] stringresult = intresult.Select(i=>i.ToString()).ToArray();

//字符转ASCII
int n = (int)(char);

//生产N位数的随机数组合
private static char[] constant = {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f',
                                  'g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v',
                                  'w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L',
                                  'M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
public static string GenerateRandomNumber(int Length) {
    System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
    Random rd = new Random();
    for (int i = 0; i < Length; i++) {
        newRandom.Append(constant[rd.Next(62)]);
    }
    return newRandom.ToString();
}
