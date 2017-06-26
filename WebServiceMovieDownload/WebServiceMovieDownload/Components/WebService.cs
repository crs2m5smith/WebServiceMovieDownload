using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Globals;
using WebServiceMovieDownload.Models;

namespace WebServiceMovieDownload.Components
{
    public  class WebService
    {
        public async Task<MovieListResponseModel> GetSimilars( int id)
        {
            var account = DBConnection.db.GetAccount();
            var endPoint = string.Format(WebServiceEndPoints._similarPoint, id.ToString(), account.ApiKey);
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(WebServiceEndPoints._basePoint);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = await client.GetAsync(endPoint);
                var jsonResonse = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<MovieListResponseModel>(jsonResonse);

                return model;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<MovieListResponseModel> GetMovies(string option)
        {
            var account = DBConnection.db.GetAccount();
            var endPoint = string.Format(WebServiceEndPoints._endPoint, option, account.ApiKey);

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(WebServiceEndPoints._basePoint);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = await client.GetAsync(endPoint);
                var jsonResonse = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<MovieListResponseModel>(jsonResonse);

                return model;
            }
            catch(Exception ex)
            {
               
            }
            return null;
        }
        public async Task<MovieDetailResponseModel> GetMovieById(int id)
        {
            var account = DBConnection.db.GetAccount();
            var endPoint = string.Format(WebServiceEndPoints._moviePoint,id.ToString(),account.ApiKey);
          
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(WebServiceEndPoints._basePoint);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = await client.GetAsync(endPoint);
                var jsonResonse = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<MovieDetailResponseModel>(jsonResonse);

                return model;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
