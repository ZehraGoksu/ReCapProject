using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
	public class MemoryCacheManager : ICacheManager // bir de memcache var
	{
		IMemoryCache _memoryCache; //microsoftun kendi servisini kullanıcağız-- bu bir interface onu çözmemiz lazım CoreModule da
								   //AdapterPattern yapıyoruz senbenim sistemime göre çalış diyoruz

		public MemoryCacheManager()
		{
			_memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>(); //coreModule de addMemoryCache ile enjection otomatik ekleniyo o instanse ı istiyoruz.
		}
		public void Add(string key, object value, int duration)
		{
			_memoryCache.Set(key, value, TimeSpan.FromMinutes(duration)); //o kadar süre için cache de kalır timespan ile zaman aralığı demek
		}

		public T Get<T>(string key)
		{
			return _memoryCache.Get<T>(key);
		}

		public object Get(string key)
		{
			return _memoryCache.Get(key);
		}

		public bool IsAdd(string key)
		{
			return _memoryCache.TryGetValue(key, out _);//ben sadece key var mı yok mu onu bilmek istiyorum datayı istemiyorum cache deki değeri ver yeter
		}

		public void Remove(string key)
		{
			_memoryCache.Remove(key);
		}

		public void RemoveByPattern(string pattern)
		{ //çalışma anında bellekten silmeye yarar bunu reflectionsla yaparız
			var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			//bellekte memoryyCache türünde olanı bul bellekte nasıl tuttuğunu bilmemiz lazım değil dokümandan bakılır
			var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
			List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
			//her bir cache elemanını gez
			foreach (var cacheItem in cacheEntriesCollection)
			{
				ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
				cacheCollectionValues.Add(cacheItemValue);
			}

			//patternı oluşturudk aşağı da
			var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
			//anahtarlardan benim gönderdiğim değere uygun olanı keystoremove a ata
			var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

			foreach (var key in keysToRemove)
			{
				_memoryCache.Remove(key);// uyanları bul ve bellekten uçuruver
			}
		}
	}
}