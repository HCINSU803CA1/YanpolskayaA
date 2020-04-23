using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using System.IO;


namespace MyConsoleServer
{
    public class Program
    {
       
        const string connectionString = @"Data Source=localhost;Initial Catalog=dbMyBase;Integrated Security=SSPI";
        const int port = 8888;

        private static string GetEmployees(int fst, int snd)
        {
            string sqlExpression = "ShowList";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter fstParam = new SqlParameter
                {
                    ParameterName = "@fst",
                    Value = fst
                };
                command.Parameters.Add(fstParam);
                SqlParameter sndParam = new SqlParameter
                {
                    ParameterName = "@snd",
                    Value = snd
                };
                command.Parameters.Add(sndParam);
                List<Employee> employees = new List<Employee>();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = reader.GetInt32(0); ;
                        emp.Name = reader.GetString(1); 
                        emp.SecondName = reader.GetString(2);
                        emp.Patronymic = reader.GetString(3);
                        emp.Age = reader.GetInt32(4);

                        employees.Add(emp);
                    }
                    
                    string json = JsonConvert.SerializeObject(employees);
                    return json;
                }

            }
            return "empty";
        }

        static void Main(string[] args)
        {
            try
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://127.0.0.1:8888/");
                listener.Start();
                
                while (true)
                {
                    Console.WriteLine("Listening...");
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    
                    if (!request.HasEntityBody)
                    {
                        Console.WriteLine("No client data was sent with the request.");
                        return;
                    }

                    Stream body = request.InputStream;
                    StreamReader reader = new StreamReader(body, request.ContentEncoding);
                    
                    var jsonRequest = reader.ReadToEnd();
                    RequestData requestData = new RequestData();
                    requestData = JsonConvert.DeserializeObject<RequestData>(jsonRequest);
                    if (String.Equals(requestData.Command, "GetData", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string unswer = GetEmployees(requestData.PageIndex, requestData.CountOfRecords);
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(unswer);
                        response.ContentLength64 = buffer.Length;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }


                    body.Close();
                    reader.Close();
                
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    
}}
