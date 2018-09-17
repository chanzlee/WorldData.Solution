using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class City
  {
    public string CityName { get; set; }
    public string CountryCode { get; set; }
    public int Population { get; set; }
    public int Id { get; }

    public City (int id, string cityName, string countryCode, int population)
    {
      CityName =  cityName;
      CountryCode =  countryCode;
      Population = population;
      Id = id;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string countryCode = rdr.GetString(2);
        int population = rdr.GetInt32(4);

        City newCity = new City(cityId, cityName, countryCode, population);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }


    public static List<City> GetFilteredCity(string filterOption, int filterValue, string orderOption)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "SELECT * FROM city WHERE "+filterOption+" > "+filterValue+" "+orderOption+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string countryCode = rdr.GetString(2);
        int population = rdr.GetInt32(4);

        City newCity = new City(cityId, cityName, countryCode, population);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static List<City> GetFilteredCity(string filterOption, string filterValue, string orderOption)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "SELECT * FROM city WHERE "+filterOption+" = '"+filterValue+"' "+orderOption+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string countryCode = rdr.GetString(2);
        int population = rdr.GetInt32(4);

        City newCity = new City(cityId, cityName, countryCode, population);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM city;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn!= null)
      {
        conn.Dispose();
      }
    }
  }
}
