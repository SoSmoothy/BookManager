using System;
using System.Collections.Generic;
using System.Text;

namespace BookConsoleApp.Framework
{
    using RoutingTable = Dictionary<string, ControllerAction>;
    
    /// <summary>
    /// delegate đại diện cho tất cả các phương thức có:
    /// - kiểu ra là void
    /// - danh sách tham số vào là Parameter
    /// </summary>
    public delegate void ControllerAction(Parameter parameter = null);
    /// <summary>
    /// Class cho phép ánh xạ truy vấn với phương thức
    /// </summary>
    public class Router
    {
        private static Router _instance;
        public static Router Instance => _instance ??= new Router();
        private readonly RoutingTable _routingTable;
        private readonly Dictionary<string, string> _helpTable;

        private Router()
        {
            _routingTable = new RoutingTable();
            _helpTable = new Dictionary<string, string>();
        }

        public string GetRoutes()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var k in _routingTable.Keys)
            {
                stringBuilder.AppendFormat("{0}, ", k);
            }

            return stringBuilder.ToString();
        }

        public string GetHelp(string key)
        {
            return _helpTable.ContainsKey(key) ? _helpTable[key] : "Chưa có hướng dẫn cụ thể";
        }
        
        /// <summary>
        /// Đăng ký 1 route mới, mỗi route ánh xạ một chuỗi truy vấn với 1 phương thức
        /// </summary>
        /// <param name="route"></param>
        /// <param name="action"></param>
        /// <param name="help"></param>
        public void Register(string route, ControllerAction action, string help = "")
        {
            if (_routingTable.ContainsKey(route)) return;
            _routingTable[route] = action;
            _helpTable[route] = help;
        }
        
        /// <summary>
        /// Phân tích truy vấn và gọi phương thức tương ứng với truy vấn
        /// 
        /// </summary>
        /// <param name="request">chuỗi truy vấn, bao gồm 2 phần route và parameter</param>
        /// <exception cref="Exception"></exception>
        public void Forward(string request)
        {
            var req = new Request(request);
            if (!_routingTable.ContainsKey(req.Route))
            {
                throw new Exception($"Không tim thấy lệnh {req.Route}");
            }

            if (req.Parameter == null)
            {
                _routingTable[req.Route]?.Invoke();
            }
            else
            {
                _routingTable[req.Route]?.Invoke(req.Parameter);
            }
        }
        
        /// <summary>
        /// Class xử lý truy vấn
        /// </summary>
        private class Request
        {
            /// <summary>
            /// Thành phần lệnh truy vấn
            /// </summary>
            public string Route { get; set; }
            
            public Parameter Parameter { get; private set; }

            public Request(string request)
            {
                Analyze(request);
            }
            
            /// <summary>
            /// Phân tích truy vấn để tách phần lệnh và thành phần tham số
            /// </summary>
            /// <param name="request"></param>
            /// <exception cref="Exception"></exception>
            public void Analyze(string request)
            {
                // tìm xem trong chuỗi có truy vấn tham số ko?
                var firstIndex = request.IndexOf('?');
                // trường hợp trong chuỗi ko có truy vấn tham số
                if (firstIndex < 0)
                    Route = request.ToLower().Trim();
                // nếu chuỗi lỗi (chỉ chứa tham số, không chứa route)
                else if (firstIndex <= 1) throw new Exception("Tham số truy vấn không hợp lệ!");
                else
                {
                    // cắt chuỗi truy vấn lấy mốc là kí tự ?
                    var tokens = request.Split(new[] {'?'}, 2, StringSplitOptions.RemoveEmptyEntries);

                    Route = tokens[0].Trim().ToLower(); // phần lệnh của truy vấn
                    var parameterPart = request.Substring(firstIndex + 1).Trim(); // phần tham số của truy vấn
                    Parameter = new Parameter(parameterPart);
                }
            }
        }
    }
}