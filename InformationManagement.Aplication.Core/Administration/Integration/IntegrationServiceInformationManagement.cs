using InformationManagement.Aplication.Core.Administration.Integration.Exceptions;
using InformationManagement.Aplication.Dto.DataTransfer_Object;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Integration
{
    public class IntegrationServiceInformationManagement : IIntegrationServiceInformationManagement
    {
        public async Task<string> ExportJson<T>(string path, T request) where T : IEnumerable<DataTransferObject>
        {
            ValidatePath(path);
            var result = JsonConvert.SerializeObject(request);

            string pathTxt = @"F:\" + path + ".json";

            using (FileStream fs = File.Create(pathTxt))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(result);
                fs.Write(info, 0, info.Length);
            }
            using (StreamReader sr = File.OpenText(pathTxt))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            return await Task.FromResult(result).ConfigureAwait(false);
        }

        public async Task<T> ImportJson<T>(string path) where T : IEnumerable<DataTransferObject>
        {
            var request = "";
            string pathTxt = @"F:\" + path + ".json";

            using (StreamReader sr = File.OpenText(pathTxt))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    request = s;
                }
            }
            return await Task.FromResult(JsonConvert.DeserializeObject<T>(request)).ConfigureAwait(false);
        }
        private static void ValidatePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new IntegrationArgumentPathException($"Parameter: {nameof(path)} required");
        }
    }
}
