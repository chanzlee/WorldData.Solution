using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class Country
  {
    public string Code { get; }
    public string Name { get; set; }
    public string Continent { get; set; }
    public string Region { get; set; }
    public int Capital { get; set; }

    public Country(string code, string name, string continent, string region, int capital)
    {
      Code = code;
      Name = name;
      Continent = continent;
      Region = region;
      Capital = capital;
    }

    public static List <Country> GetAll()
    {
      List <Country> allCountries = new List <Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        string region = rdr.GetString(3);
        int capital;
        if (!rdr.IsDBNull(13))
        {
          capital = rdr.GetInt32(13);
        }
        else
        {
          capital = 0;
        }

        Country newCountry = new Country(code, name, continent, region, capital);
        allCountries.Add(newCountry);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;
    }

    public static List <Country> GetFilteredList(string option, string value)
    {
      List <Country> filteredCountries = new List <Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM country WHERE "+option+" = '"+value+"';";
      //SELECT * FROM country WHERE continent = 'North America';
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        string region = rdr.GetString(3);
        int capital;
        if (!rdr.IsDBNull(13))
        {
          capital = rdr.GetInt32(13);
        }
        else
        {
          capital = 0;
        }

        Country newCountry = new Country(code, name, continent, region, capital);
        filteredCountries.Add(newCountry);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return filteredCountries;
    }

    public static Country GetRandomCountry()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM country ORDER BY RAND() LIMIT 1;";
      //SELECT * FROM country WHERE continent = 'North America';
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      Country newCountry;
      rdr.Read();
      string code = rdr.GetString(0);
      string name = rdr.GetString(1);
      string continent = rdr.GetString(2);
      string region = rdr.GetString(3);
      int capital;
      if (!rdr.IsDBNull(13))
      {
        capital = rdr.GetInt32(13);
      }
      else
      {
        capital = 0;
      }

      newCountry = new Country(code, name, continent, region, capital);


      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return newCountry;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM country;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
