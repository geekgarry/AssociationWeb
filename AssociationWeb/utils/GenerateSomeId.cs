using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociationWeb.utils
{
	class GenerateSomeId
	{
		public string Token()
		{
			string token= Guid.NewGuid().ToString().Replace("-", "");
			return token;
		}
		public string GenerateNum()
		{
			//获取服务器时间
			string genNum = DateTime.Now.ToString("yyyyMMddHHmmssms");
			//定义俩位的随机数
			Random rd = new Random();
			genNum += rd.Next(100, 999);
			return genNum;
		}
		//C#时间转为时间戳
		private int GetTimeStamp(DateTime dt)
		{
			DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
			int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
			return timeStamp;
		}

		public string GetTimeStamp()
		{
			TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return Convert.ToInt64(ts.TotalDays+ts.TotalHours+ts.TotalMinutes+ts.TotalSeconds+ts.TotalMilliseconds).ToString();
		}
		public string GetTimeToId()
		{
			return Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff", DateTimeFormatInfo.InvariantInfo)).ToString();
		}
		// 时间戳转为C#格式时间
		private DateTime StampToDateTime(string timeStamp)
		{
			DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			long lTime = long.Parse(timeStamp + "0000000");
			TimeSpan toNow = new TimeSpan(lTime);

			return dateTimeStart.Add(toNow);
		}

		// DateTime时间格式转换为Unix时间戳格式
		private int DateTimeToStamp(System.DateTime time)
		{
			System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
			return (int)(time - startTime).TotalSeconds;
		}
	}
}
