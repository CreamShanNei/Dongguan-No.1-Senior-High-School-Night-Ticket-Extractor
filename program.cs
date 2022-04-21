class Program
{
    //主程序
    static void Main(string[] args)
    {
        try
        {
            
            //Part 0 初始化
            //读取文件
            var NameListPath = System.Environment.CurrentDirectory + "\\名单.txt";  //读入名单文件
            var NameList = System.IO.File.ReadAllLines(NameListPath);  //将名单文件的内容存储到这个数组中

            var GotNameFile = System.Environment.CurrentDirectory + "\\已抽取名单.txt";  //读入已抽取名单文件
            var GotNameList = System.IO.File.ReadAllLines(GotNameFile);  //将已抽取名单文件的内容存储到这个数组中

            //设置一些基本变量
            var GetTicketList = new List<string>();  //存储已经获得的票
            var GetNameList = new List<string>();  //存储已经获得的名单

            string[] TicketName = {"疯味大鸡腿","章鱼小丸子","炸全鸡"};  //存储票的名字

            //输出一大堆版本信息
            Console.WriteLine("[关于] 欢迎使用夜宵券抽取系统",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 编程语言：C#",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 程序编写人：2021级14班 孙广锋",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 程序版本：2.0",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 程序更新时间：2022年4月20日",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 本程序仅供学习交流，请勿用于商业用途",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 本程序仅供东莞市第一中学使用，如有侵权请联系管理员",Console.ForegroundColor = ConsoleColor.Yellow);

            //Part 1 输入夜宵券数量
            Console.WriteLine("[信息] 名单文件路径: {0}", NameListPath,Console.ForegroundColor = ConsoleColor.White);  //输出名单文件路径
            Console.WriteLine("[信息] 名单文件内容数量: {0}", NameList.Length,Console.ForegroundColor = ConsoleColor.White);  //输出名单文件的数量

            //开始确认抽取的内容和数量
            Console.WriteLine("[信息] 首先，根据东莞市一中学特色夜宵的传统，咱们有疯味大鸡腿（周一），章鱼小丸子（周二），炸全鸡（周四、周五），所以请根据接下来的指引输入各种夜宵的数量");  //我觉得这个不需要注释吧...
            
            //输入疯味大鸡腿的数量
            Console.WriteLine("[输入] 输入你手中疯味大鸡腿的数量",Console.ForegroundColor = ConsoleColor.Green);
            var ChickenTikkaCount = int.Parse(Console.ReadLine());  

            //输入章鱼小丸子的数量
            Console.WriteLine("[输入] 输入你手中章鱼小丸子的数量",Console.ForegroundColor = ConsoleColor.Green);
            var ShrimpKababCount = int.Parse(Console.ReadLine());  

            //输入炸全鸡的数量
            Console.WriteLine("[输入] 输入你手中炸全鸡的数量",Console.ForegroundColor = ConsoleColor.Green);
            var ChickenKababCount = int.Parse(Console.ReadLine());  

            Thread.Sleep(1000);  //等待1秒

            //Part 2 抽取夜宵券
            var TicketCount = ChickenTikkaCount + ShrimpKababCount + ChickenKababCount;  //统计夜宵券的数量
            var NameListCount = NameList.Length;  //统计名单的数量

            var TempChickenTikkaCount = 0;  //临时变量，用于记录已抽取的疯味大鸡腿的数量
            var TempShrimpKababCount = 0;  //临时变量，用于记录已抽取的章鱼小丸子的数量
            var TempChickenKababCount = 0;  //临时变量，用于记录已抽取的炸全鸡的数量
            
            //开始抽取夜宵券
            Random RdTicket = new Random();  //创建随机数生成器

            while(TempChickenKababCount + TempShrimpKababCount + TempChickenTikkaCount < TicketCount)
            {
                int RdTicketType = RdTicket.Next(0,300);  //生成随机数，用于抽取夜宵券的类型
                if(RdTicketType % 3 == 0 && TempChickenTikkaCount < ChickenTikkaCount)
                {
                    Console.WriteLine("[抽取] 抽取疯味大鸡腿夜宵券",Console.ForegroundColor = ConsoleColor.Red);
                    TempChickenTikkaCount++;
                }
                else if(RdTicketType % 3 == 1 && TempShrimpKababCount < ShrimpKababCount)
                {
                    Console.WriteLine("[抽取] 抽取章鱼小丸子夜宵券",Console.ForegroundColor = ConsoleColor.Red);
                    TempShrimpKababCount++;
                }
                else if(RdTicketType % 3 == 2 && TempChickenKababCount < ChickenKababCount)
                {
                    Console.WriteLine("[抽取] 抽取炸全鸡夜宵券",Console.ForegroundColor = ConsoleColor.Red);
                    TempChickenKababCount++;
                }
            }

            //Part 3 抽人
            //读取已经抽过人的名单
            if(GotNameList.Length > 0)
            {
                Console.WriteLine("[信息] 已经抽过人的名单：{0}", GotNameList.ToString(),Console.ForegroundColor = ConsoleColor.White);
            }
            else
            {
                Console.WriteLine("[信息] 已经抽过人的名单：{0}", "无",Console.ForegroundColor = ConsoleColor.White);
            }
            Thread.Sleep(5000);  //等待5秒

        }
        //找不到文件
        catch(System.IO.FileNotFoundException)
        {
            Console.WriteLine("[错误] 无法找到文件 NameList.txt",Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("[错误] 请检查文件是否存在",Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("[文件处理] 正在创建默认文件 NameList.txt",Console.ForegroundColor = ConsoleColor.Green);
            var TempNameListPath = System.Environment.CurrentDirectory + "\\名单.txt";
            var TempNameList = new string[] { "张三", "李四", "王五" };
            System.IO.File.WriteAllLines(TempNameListPath, TempNameList);
            Console.WriteLine("[文件处理] 已创建默认文件 NameList.txt",Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine("[信息] 请重新运行程序",Console.ForegroundColor = ConsoleColor.White);
            Thread.Sleep(5000);
        }
        
    }
}