#r "System.Runtime.Serialization"
#r "Newtonsoft.Json"


using System.Net;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

[DataContract(Name = "RequestData", Namespace = "http://functions")]
 public class User
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Profile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PromoCode { get; set; }

        public List<User> getAllUsers()
        {
            List<User> userList = new List<User>();          
            userList.Add(new User { ID = "0", UserName = "İbrahim Kıvanç", Profile = "Gold Class" ,Email= "xx@email.com" });           
            userList.Add(new User { ID = "1", UserName = "Onur Koç", Profile = "Platinum Class" , Email= "yy@email.com" });
            userList.Add(new User { ID = "2", UserName = "Cavit Yantaç", Profile = "Platinum Class",  Email= "zz@email.com" });
            userList.Add(new User { ID = "3", UserName = "Goksin Bakır", Profile = "Platinum Class" , Email= "vv@email.com" });
            userList.Add(new User { ID = "4", UserName = "Melih Mahmutoğlu", Profile = "Gold Class" , Email= "ww@email.com" });
            return userList;
        }

        public User getUserByName(string uName)
        {
            User result = getAllUsers().FirstOrDefault(x => x.UserName.ToLower().Contains(uName.ToLower()));
            return result;
        }
    }

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;

    User result = new User();
    if (name == null)
    {
        // Request'in Body'sini al
        dynamic data = await req.Content.ReadAsAsync<object>();
        name = data?.name;

        //
        //Promosyon için kod üretilmesi.
        //
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var promocode = new string(
        Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

        //
        //Kullanıcı bilgilerinin çekileceği ve Promosyonun üretildiği yer 
        //
        User udata = new User();
        result = udata.getUserByName(name);
        result.PromoCode = promocode;

        //Log'ların ekrana yazdırılması
        log.Info("Merhaba " + result.UserName);
        log.Info("email: " + result.Email);
        log.Info("profile: " + result.Profile);
        log.Info("promocode: " + result.PromoCode);
    }
    
    var jsonresult = JsonConvert.SerializeObject(result);

     return new HttpResponseMessage(HttpStatusCode.OK) {
        Content = new StringContent(jsonresult, Encoding.UTF8, "application/json")
    };
}
