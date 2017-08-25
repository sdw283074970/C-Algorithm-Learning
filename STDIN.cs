//读取int
int n = Convert.ToInt32(Console.ReadLine());
//将string类型的标准输入转化为int[]类型数组读取
int[] s = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);

//将int[]类型数组转化为string[]类型数组
string[] stringresult = intresult.Select(i=>i.ToString()).ToArray();
