 1a.

Bốn trụ cột của lập trình hướng đối tượng (OOP):
1. Tính đóng gói (Encapsulation): Che giấu trạng thái bên trong của đối tượng và chỉ cho phép truy cập thông qua các phương thức công khai. 
   Minh họa: Lớp `Member` trong tệp `Member.cs` (các thuộc tính được khai báo với `private set`).
2. Tính kế thừa (Inheritance): Cho phép một lớp mới (lớp con) kế thừa các thuộc tính và phương thức từ một lớp đã có (lớp cha).
   Minh họa: (Sẽ trình bày ở câu 3, khi các lớp `EmailNotificationService` và `SmsNotificationService` cùng thực thi interface `INotificationService`).
3. Tính đa hình (Polymorphism): Cùng một tên phương thức nhưng có thể được thực thi theo nhiều cách khác nhau tùy thuộc vào đối tượng gọi nó.
   Minh họa: Phương thức `Send()` trong interface `INotificationService` được cài đặt khác nhau ở lớp Email và Sms.
4. Tính trừu tượng (Abstraction): Ẩn đi sự phức tạp của hệ thống, chỉ hiển thị những tính năng cốt lõi cần thiết.
   Minh họa: Interface `IEventRepository` trong tệp `IEventRepository.cs` (chỉ định nghĩa các hàm cần có mà không quan tâm cách lưu trữ).

1b.

Hai vấn đề của lớp Member ban đầu:
1. Các thuộc tính (Id, Email) được khai báo với `public set`, nên bất kỳ đoạn code nào bên ngoài cũng có thể sửa đổi dữ liệu tùy ý, phá vỡ tính đóng gói.
2. Lớp không có bất kỳ bước kiểm tra dữ liệu nào khi khởi tạo. Người dùng có thể tạo một Member với Email rỗng hoặc không có ký tự `@` (như dòng 9 trong đề bài).

2a.

Sơ đồ trạng thái của Registration:
```mermaid
stateDiagram-v2
    [*] --> Pending : Create
    Pending --> Confirmed : Confirm()
    Pending --> Cancelled : Cancel()
    Confirmed --> Cancelled : Cancel()
    Cancelled --> [*]

Câu 3a.

Lớp EventService vi phạm 3 nguyên lý SOLID:
1. SRP (Single Responsibility Principle) - Vi phạm dòng 8, 9, 10, 11-14. Lớp này ôm đồm quá nhiều việc: kiểm tra dữ liệu, kết nối DB, ghi log file, và gửi thông báo.
2. OCP (Open/Closed Principle) - Vi phạm dòng 11-14. Dùng if/else để chọn kênh gửi tin. Nếu muốn thêm kênh Zalo, phải sửa lại code bên trong lớp này thay vì mở rộng ra bên ngoài.
3. DIP (Dependency Inversion Principle) - Vi phạm dòng 8, 12, 13. Lớp này khởi tạo trực tiếp (new) các lớp cụ thể như `SqlConnection`, `EmailSender`, `SmsSender` thay vì phụ thuộc vào abstraction (interface).