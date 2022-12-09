using System.Net;

var server = new HttpListener();

server.Prefixes.Add("http://127.0.0.1:1488/api/"); 

server.Start();

while (true)
{
    var context = await server.GetContextAsync();
    var request = context.Request;
    
    Console.WriteLine();
}

// server.Stop();
// server.Close();