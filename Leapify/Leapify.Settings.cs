using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Leapify
{
    /// <summary>
    /// Thanks to T. Manjaly for the documentation on how to interact with Isolated Storage
    /// http://www.codeproject.com/Articles/6535/Isolated-Storage-in-NET-to-store-application-data
    /// </summary>
    internal class LeapifySettings
    {
        private string _IsolatedSettingsFile = "Leapify.config";
        private IsolatedStorageFile _storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

        internal async Task<Models.Settings> Read()
        {
            var files = _storage.GetFileNames(_IsolatedSettingsFile);

            if (!files.Any())
            {
                return BuildNewConfig();
            }

            var storageFs = new IsolatedStorageFileStream(_IsolatedSettingsFile, System.IO.FileMode.Open, _storage);
            var reader = new StreamReader(storageFs);

            var settingsJson = await reader.ReadToEndAsync();
            var settingsData = await JsonConvert.DeserializeObjectAsync<Models.Settings>(settingsJson);
            reader.Close();

            if (string.IsNullOrWhiteSpace(settingsData.ConfigVersion) || settingsData.ConfigVersion != Application.ProductVersion)
            {
                return BuildNewConfig();
            }

            return settingsData;
        }

        internal async Task Update(Models.Settings settingsData)
        {
            settingsData.ConfigVersion = Application.ProductVersion;
            var storageFs = new IsolatedStorageFileStream(_IsolatedSettingsFile, System.IO.FileMode.Create, _storage);
            var writer = new StreamWriter(storageFs);

            var settingsJson = await JsonConvert.SerializeObjectAsync(settingsData);
            await writer.WriteAsync(settingsJson);
            writer.Close();
        }

        internal Models.Settings BuildNewConfig()
        {
            return new Models.Settings
            {
                ConfigVersion = Application.ProductVersion,
                DistanceRequired = 100,
                SpeedRequired = 100,
                SwipeFingersRequired = 2,
                SwipeToolsRequired = 0,
                TapFingersRequired = 2,
                TapToolsRequired = 0,
                TimeBeforeNextAction = 500,
                VolumeSpeedIncrease = 1
            };
        }
    }
}
