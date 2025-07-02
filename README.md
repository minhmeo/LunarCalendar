# LunarCalendar 
# Initiated 2010
# Author: Nguyen Hoang Minh
# Original Language: C Sharp

This project is to create the repeat events based on Lunar Calendar and can easily import back to Google Calendar

# Vietnamese
Dự án nhỏ này cho phép bạn liệt kê 1 loạt các sự kiện theo lịch âm, ứng dụng sẽ tự động tính toán ngày dương lịch tương ứng và tạo các event nhắc nhở cho các năm tiếp theo, xuất ra dưới dạng file text có thể import vào Google Calendar để nhắc nhở các sự kiện quan trọng như các ngày Lễ, Tết, các ngày giỗ, sinh nhật theo lịch âm.

# Format file input:

#n
dd/MM: Event title
dd/MM: Event title
dd/MM: Event title
dd/MM: Event title
dd/MM: Event title
dd/MM: Event title

# Giải thích
- n: số năm sự kiện lặp (tối thiểu 2, tối đa 20 năm).
- dd: ngày âm lịch (01–30), riêng ký tự đặc biệt e là ngày cuối tháng.
- MM: tháng âm lịch (01–12).

## 🎯 Ví dụ minh họa và biến đặc biệt
#5
10/03: Giỗ tổ Hùng Vương
23/12: Ông Táo Chầu Trời
e/12: Giao thừa

## 📌 Giải thích thuật toán và chức năng từng file

### 1️⃣ Program.cs
- Khởi tạo giao diện người dùng (Windows Forms).
- Nhận input (ngày âm lịch, sự kiện).
- Truyền dữ liệu sang các module xử lý.

### 2️⃣ LunarMethods.cs
**Chuyển đổi ngày âm lịch sang dương lịch:**
- Dùng thuật toán Julian Day Number (JDN).
- Kiểm tra năm/tháng nhuận.
- Xử lý trường hợp ngày cuối tháng.

> Âm lịch → Julian Day Number → Dương lịch

### 3️⃣ processString.cs
- Xử lý file input dạng text.
- Tách ngày, tháng, tên sự kiện.

### 4️⃣ ExportAD.cs
**Tạo và xuất file `.ical` theo chuẩn RFC 5545:**
BEGIN:VCALENDAR
VERSION:2.0
CALSCALE:GREGORIAN
BEGIN:VEVENT
SUMMARY:Tên sự kiện
DTSTART;VALUE=DATE:yyyymmdd
DTEND;VALUE=DATE:yyyymmdd
END:VEVENT
END:VCALENDAR

## 🚩 Quy trình tổng thể
Input (text file)
→ processString.cs
→ LunarMethods.cs
→ ExportAD.cs
→ output.ical

## 📚 Tài liệu và nguồn tham khảo liên quan
- [Thuật toán lịch Âm-Dương Việt Nam](https://www.informatik.uni-leipzig.de/~duc/amlich/calrules.html)
- [Chuẩn RFC 5545 (iCalendar)](https://tools.ietf.org/html/rfc5545)

## 🔖 Kết luận
Tài liệu này giúp bạn hiểu rõ các thuật toán và phương pháp được sử dụng trong ứng dụng C#, dễ dàng chuyển đổi hoặc phát triển thêm.
