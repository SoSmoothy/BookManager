using System;
using System.Collections.Generic;

namespace BookConsoleApp.Framework
{
    /// <summary>
    /// Lưu các cặp khoá-giá trị người dùng nhập
    /// chuỗi tham số cần viết ở dạng khoá = giá trị
    /// nếu có nhiều tham số thì viết tách nhau với ký tự &
    /// </summary>
    public class Parameter
    {
        private readonly Dictionary<string, string> _pairs = new Dictionary<string, string>();
        
        
        /// <summary>
        /// Overloading phép toán indexing [], cho phép truy cập giá trị theo kiểu biến[khoá] = giá trị;
        /// </summary>
        /// <param name="key">Khoá</param>
        /// <returns>Giá trị tương ứng với key</returns>
        public string this[string key]
        {
            get
            {
                if (_pairs.ContainsKey(key))
                    return _pairs[key];
                else return null;
            }
            set => _pairs[key] = value;
        }
        
        /// <summary>
        /// Kiểu tra xem một khoá có trong danh sách tham số không?
        /// </summary>
        /// <param name="key">Khoá</param>
        /// <returns>true/false</returns>
        public bool ContainsKey(string key)
        {
            return _pairs.ContainsKey(key);
        }

        public Parameter(string parameter)
        {
            // Cắt chuỗi theo môc kí tự là &
            // kết quả của là 1 mảng, mỗi phần tử là một chuỗi có dạng khoá = giá trị;
            var pairs = parameter.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var p = pair.Split('='); // cắt mỗi phần tử lấy mốc là kí tự =
                if (p.Length == 2) // một cặp khoá và giá trị sau khi cắt sẽ phải có 2 phần tử
                {
                    var key = p[0].Trim(); // phần tử thứ 1 là khoá
                    var value = p[1].Trim(); // phần tử thứ 2 là giá trị
                    this[key] = value; // <=> _pairs[key] = value => Lưu key và value
                }
            }
        }
    }
}