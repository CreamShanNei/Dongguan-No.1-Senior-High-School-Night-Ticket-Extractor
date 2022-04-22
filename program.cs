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
            var GotNameListFromFile = System.IO.File.ReadAllLines(GotNameFile);  //将已抽取名单文件的内容存储到这个数组中
            var GotNameList = new string[14];  //临时变量，存储本次已抽取名单
            var GotTicketList = new string[14];  //临时变量，存储已经获得的票

            string[] TicketName = {"疯味大鸡腿","章鱼小丸子","炸全鸡"};  //存储票的名字

            //输出一大堆版本信息
            Console.WriteLine("[关于] 欢迎使用夜宵券抽取系统",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 编程语言：C#",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 程序编写人：2021级14班 孙广锋",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 程序版本：2.0",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 程序更新时间：2022年4月20日",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 本程序仅供学习交流，请勿用于商业用途",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("[关于] 项目仓库地址：https://github.com/CreamShanNei/Dongguan-No.1-Senior-High-School-Night-Ticket-Extractor",Console.ForegroundColor = ConsoleColor.Yellow);
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

            //Part 2 抽取夜宵券
            var TicketCount = ChickenTikkaCount + ShrimpKababCount + ChickenKababCount;  //统计夜宵券的数量
            var NameListCount = NameList.Length;  //统计名单的数量

            var TempChickenTikkaCount = 0;  //临时变量，用于记录已抽取的疯味大鸡腿的数量
            var TempShrimpKababCount = 0;  //临时变量，用于记录已抽取的章鱼小丸子的数量
            var TempChickenKababCount = 0;  //临时变量，用于记录已抽取的炸全鸡的数量
            
            var TotleTicketCount = TempChickenKababCount + TempShrimpKababCount + TempChickenTikkaCount;  //统计已经抽取的夜宵券的数量
            

            //开始抽取夜宵券
            Random RdTicket = new Random();  //创建随机数生成器

            Array.Resize(ref GotTicketList, TicketCount);  //重新设置数组的大小
            while(TotleTicketCount < TicketCount)
            {
                for(int i = 0 ; i < GotTicketList.Length ; i ++)
                {
                    int RdTicketType = RdTicket.Next(0,300);  //生成随机数，用于抽取夜宵券的类型
                    if(RdTicketType % 3 == 0 && TempChickenTikkaCount < ChickenTikkaCount)
                    {
                        TempChickenTikkaCount++;
                        Console.WriteLine("[抽取] 抽取了一张疯味大鸡腿的夜宵券",Console.ForegroundColor = ConsoleColor.Green);
                        GotTicketList[i] = "疯味大鸡腿";
                    }
                    else if(RdTicketType % 3 == 1 && TempShrimpKababCount < ShrimpKababCount)
                    {
                        TempShrimpKababCount++;
                        Console.WriteLine("[抽取] 抽取了一张章鱼小丸子的夜宵券",Console.ForegroundColor = ConsoleColor.Green);
                        GotTicketList[i] = "章鱼小丸子";
                    }
                    else if(RdTicketType % 3 == 2 && TempChickenKababCount < ChickenKababCount)
                    {
                        TempChickenKababCount++;
                        Console.WriteLine("[抽取] 抽取了一张炸全鸡的夜宵券",Console.ForegroundColor = ConsoleColor.Green);
                        GotTicketList[i] = "炸全鸡";
                    }
                    else
                    {
                        Console.WriteLine("[重复] 抽到了一张重复的票，重新抽取",Console.ForegroundColor = ConsoleColor.Red);
                        i--;
                    }

                TotleTicketCount = TempChickenKababCount + TempShrimpKababCount + TempChickenTikkaCount;
                Thread.Sleep(100);
                } 
            }

            Console.WriteLine("[信息] 夜宵券抽取完毕，共抽取{0}张夜宵券",TotleTicketCount,Console.ForegroundColor = ConsoleColor.White);  //输出抽取夜宵券的数量
            
            //Part 3 抽人
            //读取已经抽过人的名单
            Random NameRd = new Random();  //创建随机数生成器
            for(int i = 0 ; i < TicketCount ; i++)
            {
                int NameRdType = NameRd.Next(0,NameListCount);  //生成随机数，用于抽取名单的下标
                if(GotNameList.Contains(NameList[NameRdType]))
                {
                    Console.WriteLine("[重复] 当前抽到人名：{0}，该人名包含在已抽过人的本次抽取名单中，重新抽取",NameList[NameRdType],Console.ForegroundColor = ConsoleColor.Red);
                    i--;
                }
                else if(GotNameListFromFile.Contains(NameList[NameRdType]))
                {
                    Console.WriteLine("[重复] 当前抽到人名：{0}，该人名包含在已抽过人的过去抽取名单文件中，重新抽取",NameList[NameRdType],Console.ForegroundColor = ConsoleColor.Red);
                    i--;
                }
                else
                {
                    Array.Resize(ref GotNameList,GotNameList.Length + 1);
                    GotNameList[i] = NameList[NameRdType];  //把抽取的名单添加到已抽取的名单列表中
                    Console.WriteLine("[抽取] 当前抽到人名：{0}", NameList[NameRdType],Console.ForegroundColor = ConsoleColor.Green);  //输出抽取的名单
                }

                Thread.Sleep(100);  //等待0.1秒
            }            

            Console.WriteLine("[信息] 所有内容抽取完毕，5秒钟后输出本次抽取的结果");
            
            Thread.Sleep(5000);  //等待5秒

            Console.WriteLine("\n");
            for(int i = 0 ; i < GotTicketList.Length - 2 ; i ++)
            {
                Console.WriteLine("[抽取] 已抽取的人名：{0}，对应的夜宵券：{1}", GotNameList[i],GotTicketList[i],Console.ForegroundColor = ConsoleColor.Yellow);
            }


            //Part 4 存储已抽取的名单
            //将已抽取的名单写入文件
            Console.WriteLine("[信息] 正在将已抽取的名单写入文件中",Console.ForegroundColor = ConsoleColor.White);
            string FilePath = System.Environment.CurrentDirectory + "\\" + "已抽取名单.txt";
            FileStream fs = new FileStream(FilePath,FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for(int i = 0 ; i < GotNameList.Length - 1 ; i ++)
            {
                sw.WriteLine(GotNameList[i]);
            }
            for(int i = 0 ; i < GotNameListFromFile.Length - 1 ; i ++)
            {
                sw.WriteLine(GotNameListFromFile[i]);
            }
            sw.Close();
            fs.Close();

            //结果写入完毕
            Console.WriteLine("[信息] 已抽取的名单已经写入文件，5分钟后程序自动退出",Console.ForegroundColor = ConsoleColor.White);
            Thread.Sleep(300000);  //等待5分钟

        }
        //找不到文件
        catch(System.IO.FileNotFoundException)
        {
            Console.WriteLine("[错误] 无法找到文件 名单.txt",Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("[错误] 请检查文件是否存在",Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("[文件处理] 正在创建默认文件 名单.txt",Console.ForegroundColor = ConsoleColor.Green);
            var TempNameListPath = System.Environment.CurrentDirectory + "\\名单.txt";
            var TempNameList = new string[] { "张三", "李四", "王五" };
            System.IO.File.WriteAllLines(TempNameListPath, TempNameList);
            Console.WriteLine("[文件处理] 已创建默认文件 名单.txt",Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine("[信息] 请重新运行程序",Console.ForegroundColor = ConsoleColor.White);
            Thread.Sleep(5000);
        }
        
    }
}