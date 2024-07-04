# ĐỒ ÁN: ỨNG DỤNG QUẢN LÝ ĐIỂM SINH VIÊN
**Nhóm 15:**

- Trần Thu Ngân - 22520937 ([Nene1724](https://github.com/Nene1724))
- Nguyễn Kim Khánh - 22520643 ([kikasssss](https://github.com/kikasssss))
- Lăng Thị Cẩm Nhung - 22521057 ([CamNhungJB](https://github.com/CamNhungJB))
- Trần Anh Khôi - 22520701 ([anhkhoi312](https://github.com/anhkhoi312/))

**Giảng viên hướng dẫn:** Trần Hồng Nghi 
## <p align="center"><ins>A. Mô tả đề tài</ins></p>
![](MindMap/MindMap.png)
### <ins>A.1 Tổng quan đề tài</ins>
- Đăng nhập (Giảng viên, sinh viên) 
- Về phía người dùng là Sinh viên: Xem điểm, xem hạng, xếp loại 
- Về phía người dùng là Giảng viên: Nhập điểm, Đánh giá sinh viên, Tạo thông báo 
- Có chatbox giữa sinh viên và giảng viên
- Thông báo về khi giáo viên nhập điểm mới
### <ins>A.2 Công nghệ sử dụng</ins>
- Phía người dùng (client): Windows Forms .NET, C# 
- Phía server: Windows Forms .NET, C# 
- Thiết kế giao diện: canva 
- Database: Chức năng FireStore Database của Firebase 

Lý do chọn công nghệ: chức năng Realtime Database là giải pháp hiệu quả, độ trễ thấp cho các ứng yêu cầu trạng thái được đồng bộ hoá theo thời gian thực. Nếu xét về nhu cầu chỉ để lưu trữ lịch sử trận đấu, thì Realtime Database là quá mức cần thiết cho đề tài này. Nhưng vì cấu trúc lưu trữ là No-SQL, đơn giản, miễn phí, dễ sử dụng nên chúng em đã quyết định chọn sản phẩm này. 
### <ins>A.3 Mục tiêu nghiên cứu</ins>
- Phần mềm dễ sử dụng, có tính khả thi, đầy đủ thông tin, tránh dư thừa thông tin.  
- Hỗ trợ cho công tác quản lý giáo viên, sinh viên một cách thuận lợi.  
- Hỗ trợ cho công tác quản lý trong việc cập nhật, sửa đổi, tra cứu, tra cứu thông tin liên quan đến sinh viên về điểm của sinh viên.  
- Tiết kiệm thời gian, công sức thay thế các công việc làm bằng thủ công dựa trên giấy tờ.
  <br />
  <br />
  <table>
  <thead>
    <tr>
      <th style="text-align:center;">Chức năng</th>
      <th style="text-align:center;">Mô tả</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Đăng nhập (có 2 chế độ: Giảng viên và Sinh viên)</td>
      <td>Đăng nhập tài khoản để vào ứng dụng</td>
    </tr>
  </tbody>
<table>
  <thead>
    <tr>
      <th colspan="2" style="text-align:center;">Giảng viên</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>Nhập điểm</strong></td>
      <td>Giảng viên có thể chọn lớp/sinh viên để nhập điểm.</td>
    </tr>
    <tr>
      <td><strong>Thống kê</strong></td>
      <td>Giảng viên có thể xem thống kê điểm của từng lớp</td>
    </tr>
    <tr>
      <td><strong>Thông báo</strong></td>
      <td>Giảng viên có thể thông báo đến lớp hoặc một sinh viên.</td>
    </tr>
    <tr>
      <td><strong>Quản lí danh sách lớp</strong></td>
      <td>Giảng viên có thể thêm/xóa/sửa/tìm kiếm một sinh viên</td>
    </tr>
    <tr>
      <td><strong>Thông tin giảng viên</strong></td>
      <td>Có các thông tin về giảng viên</td>
    </tr>
  </tbody>
</table>
<br />
<table>
  <thead>
    <tr>
      <th colspan="2" style="text-align:center;">Sinh viên</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>Xem điểm</strong></td>
      <td>Sinh viên có thể xem điểm các môn học của mình.</td>
    </tr>
    <tr>
      <td><strong>Thông báo</strong></td>
      <td>Sinh viên có thể nhận thông báo từ giảng viên, hoặc có thể nhắn tin cho giảng viên.</td>
    </tr>
        <tr>
      <td><strong>Thông tin sinh viên </strong></td>
      <td>Có các thông tin về sinh viên.</td>
    </tr>
  </tbody>
</table>

### <ins>A.4 Đối tượng và phạm vi nghiên cứu</ins>
#### Đối tượng
- Kỹ thuật lập trình socket, sử dụng các giao thức mạng TCP/IP, UDP để kết nối người dùng qua mạng LAN  
- Tìm hiểu về Windows Forms .NET để xây dựng giao diện, các chức năng cho phần mềm.  
- Tìm hiểu về Firebase để thực hiện database lưu trữ dữ liệu người dùng. 
#### Phạm vi nghiên cứu 
- Đề tài được xây dựng cho máy tính / laptop chạy hệ điều hành windows. Đề tài được thực hiện, hoàn thiện một sản phẩm cụ thể và được kiểm tra, thử nghiệm ở quy mô nhỏ.


