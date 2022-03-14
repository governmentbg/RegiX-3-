using Microsoft.Extensions.Caching.Distributed;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace RegiX.Info.Services.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IDatabaseOperationRepository aRepo;
        private readonly IDistributedCache distributedCache;

        public StatisticsService(IDatabaseOperationRepository aRepo, IDistributedCache distributedCache)
        {
            this.aRepo = aRepo;
            this.distributedCache = distributedCache;
        }

        public Records CallStatisticsProcedure(string timeFrame, bool showErrors)
        {
            var result = this.distributedCache.GetString(timeFrame);
            if (String.IsNullOrEmpty(result))
            {
                var statistics = this.aRepo.StatisticsProcedure(timeFrame, showErrors);
                //if no data is found return empty list
                if (statistics[0].Records != null)
                {
                    var res = statistics[0].Records.XmlDeserialize<Records>();
                    res.RefreshedTime = DateTime.Now;

                    this.distributedCache.SetString(timeFrame, res.XmlSerialize(), new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                    });

                    return res;
                }

                return new Records() { RefreshedTime = DateTime.Now};
            }
            else
            {
                var resultObject = result.XmlDeserialize<Records>();
                return resultObject;
            }
        }

        public int GetMonthRecords(string yearMonth)
        {
            var result = this.distributedCache.GetString(yearMonth);
            if (String.IsNullOrEmpty(result))
            {
                var match = Regex.Match(yearMonth, "");

                var date = DateTime.ParseExact(yearMonth, "yyyy-MM", null);
                var recordsCount = this.aRepo.GetMonthRecords(date.Year, date.Month);

                this.distributedCache.SetString(yearMonth, recordsCount.ToString(), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                });
                return recordsCount;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

    }

    public static class ObjectExtensions{

        public static T XmlDeserialize<T>(this string serializedObject)
            where T : class
        {
            return XmlDeserialize(serializedObject, typeof(T)) as T;
        }

        /// <summary>
        /// Deserializes the provided string to the desired object
        /// </summary>
        /// <param name="serializedObject">Serialized object</param>
        /// <param name="type">Type of the serialized object</param>
        /// <returns>Deserialzed object</returns>
        public static object XmlDeserialize(this string serializedObject, Type type)
        {
            if (string.IsNullOrEmpty(serializedObject))
            {
                return null;
            }
            using (StringReader sr = new StringReader(serializedObject))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(sr);
            }
        }

        /// <summary>
        /// Serializes an object to XML and returns string
        /// </summary>
        /// <param name="obj">The object that contains the data to be serialized</param>
        /// <returns>The serialized object</returns>
        public static string XmlSerialize(this Object obj)
        {
            if (obj != null)
            {
                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(ms, obj);
                    ms.Seek(0, SeekOrigin.Begin);
                    return sr.ReadToEnd();
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}