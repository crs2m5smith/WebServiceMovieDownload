using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceMovieDownload.Interfaces
{
    public interface ISharedPreference
    {
        bool GetBool(string key);
        int GetInt(string key);
        float GetFloat(string key);
        string GetString(string key);

        void SetBool(string key, bool value);
        void SetInt(string key, int value);
        void SetFloat(string key, float value);
        void SetString(string key, string value);




    }

}
