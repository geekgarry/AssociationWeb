﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociationWeb.utils
{
	class GenerateVerifyCode
	{
		//方法一：随机生成不重复数字字符串
		private int rep = 0;

		/// 
		/// 生成随机数字字符串
		/// 
		/// 待生成的位数
		/// 生成的数字字符串
		public string GenerateCheckCodeNum(int codeCount)
		{
			string str = string.Empty;
			long num2 = DateTime.Now.Ticks + this.rep;
			this.rep++;
			Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this.rep)));
			for (int i = 0; i < codeCount; i++)
			{
				int num = random.Next();
				str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
			}
			return str;
		}
		//方法二：随机生成字符串（数字和字母混和） 
		/// 生成随机字母字符串(数字字母混和)
		/// 
		/// 待生成的位数
		/// 生成的字母字符串
		public string GenerateCheckCode(int codeCount)
		{
			string str = string.Empty;
			long num2 = DateTime.Now.Ticks + this.rep;
			this.rep++;
			Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this.rep)));
			for (int i = 0; i < codeCount; i++)
			{
				char ch;
				int num = random.Next();
				if ((num % 2) == 0)
				{
					ch = (char)(0x30 + ((ushort)(num % 10)));
				}
				else
				{
					ch = (char)(0x41 + ((ushort)(num % 0x1a)));
				}
				str = str + ch.ToString();
			}
			return str;
		}
		//方法三、
		private static char[] constant =
		{
		'0','1','2','3','4','5','6','7','8','9',
		'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
		'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
		};
		public static string GenerateRandomNumber(int Length)
		{
			System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
			Random rd = new Random();
			for (int i = 0; i < Length; i++)
			{
				newRandom.Append(constant[rd.Next(62)]);
			}
			return newRandom.ToString();
		}

		//方法四、
		/*Random ran = new Random();
		for(int i=0;i<10;i++)
		{
			int RandKey = ran.Next(100000000, 999999999);
		}*/

		//方法五、
		//Console.WriteLine(Guid.NewGuid().ToString());

		//方法六、

		/*for (int i = 0; i< 10; i++)
		{
		RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider()
		byte[] byteCsp = new byte[10];
		csp.GetBytes(byteCsp);
		Console.WriteLine(BitConverter.ToString(byteCsp));
		}*/
	}
}
