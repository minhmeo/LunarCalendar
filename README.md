# LunarCalendar 
# Initiated 2010
# Author: Nguyen Hoang Minh

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
	•	n: số năm sự kiện lặp (tối thiểu 2, tối đa 20 năm).
	•	dd: ngày âm lịch (01–30), riêng ký tự đặc biệt e là ngày cuối tháng.
	•	MM: tháng âm lịch (01–12).

# Ví dụ và biến đặc biệt
#5
10/03: Giỗ tổ Hùng Vương
23/12: Ông Táo Chầu Trời
e/12: Giao thừa
