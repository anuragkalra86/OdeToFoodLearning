using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public class Program
    {
        string _timeZone1 = "Central Standard Time";
        string _timeZone2 = "Eastern Standard Time";
        Program() { }
        Program(string timeZone1, string timeZone2)
        {
            _timeZone1 = timeZone1;
            _timeZone2 = timeZone2;
        }
        void DoStuff()
        {
            TimeZoneInfo _timeZoneID1 = TimeZoneInfo.FindSystemTimeZoneById(_timeZone1);
            TimeZoneInfo _timeZoneID2 = TimeZoneInfo.FindSystemTimeZoneById(_timeZone2);
            DateTime currentTime = DateTime.Now;
            DateTime convertedTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, _timeZone2, _timeZone1);
            Console.WriteLine("Current time: {0}. Converted time: {1} ", currentTime, convertedTime);
        }

        void DoStuff2()
        {
            var inDatetime = new DateTime(2017, 01, 26, 12, 49, 30);
            DateTime outTime = getVerifierDateTimeOffset(inDatetime, _timeZone1);
            Console.WriteLine("Current time: {0}. Converted time: {1} ", inDatetime, outTime);
        }

        void DoStuff3()
        {
            var inDatetime = new DateTime(2017, 01, 26, 12, 49, 30);
            DateTime outTime = getVerifierDateTimeOffset(inDatetime, _timeZone1);
            //Console.WriteLine("Current time: {0}. Converted time: {1} ", inDatetime, outTime);
            //DateTime localDateTimeAgain = TimeZoneInfo.ConvertTimeToUtc(outTime).ToLocalTime

            DateTime localDateTimeAgain = getVerifierDateTimeOffset(inDatetime, _timeZone2);
            Console.WriteLine("Current time: {0}. Converted time: {1}. Converted to local again: {2} ", inDatetime, outTime, localDateTimeAgain);
        }
        public DateTime getVerifierDateTimeOffset(DateTime requestDateTime, string targetTimezone)
        {
            try
            {
                DateTimeOffset requestDateOffset = new DateTimeOffset(requestDateTime);
                TimeZoneInfo targetZone = TimeZoneInfo.FindSystemTimeZoneById(targetTimezone);
                var universalRequestTime = requestDateOffset.ToUniversalTime();
                var targetRequestTime = TimeZoneInfo.ConvertTime(universalRequestTime, targetZone).DateTime;
                return targetRequestTime;
            }
            catch (Exception e)
            {
                //return the date as is
                return requestDateTime;
            }
        }

        static void Main(string[] args)
        {
            new Program().DoStuff3();
            Console.ReadKey();
        }
    }
}
