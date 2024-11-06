# Phần mềm Desktop hỗ trợ bán cây cảnh cho cửa hàng nhỏ
## Mục lục
- [1. Tài liệu liên quan](#1-tài-liệu-liên-quan)
- [2. Cấu trúc thư mục](#2cấu-trúc-thư-mục)
- [3. Xây dựng](#3xây-dựng)
- [4. Thành viên](#4thành-viên)
- [Milestone 1](#milestone-1---phần-mềm-desktop-hỗ-trợ-bán-cây-cảnh-cho-cửa-hàng-nhỏ)
## 1. Tài liệu liên quan
- [Project Proposal](https://docs.google.com/document/d/1Hj6Q5HjQI0jAnwcUftC8F3FNiSuzF9Qpq5v6lFGt1bU/edit?tab=t.0)
- [Team contract](https://drive.google.com/drive/u/0/folders/12oLrn32yTwEjtjTBcGdDud1h_aw492Fj)
- [Sơ đồ cơ sở dữ liệu](https://drive.google.com/file/d/1zT2zWdo6J85sI8139Cm5ktiiAA4DYgjF/view?usp=sharing)
- [Weekly report](https://docs.google.com/document/d/1iQYVuPzyaplpwK5XBr-9gkO3xkDSdZ2dSiQfACDi4PM/edit?tab=t.0)
- [Achitecture](https://docs.google.com/document/d/1vKVmfa_STMEWTUNRw-rj-qx10GQ8lNln3-Nun_TDNq4/edit?tab=t.0)
- [Quality assurance](https://docs.google.com/document/d/18K6-XzoG4_geuWmBobziRP1cqJmBmR-yHVIyzClmBRQ/edit?tab=t.0)
## 2.Cấu trúc thư mục
```text
SellingTree/
├── Properties
|   └── ...    
├── Helper/
|   ├── FullObservableCollection.cs
|   ├── QuantityToStringIConverter.cs
|   ├── IntToVNDIConverter.cs
|   └── IntToVND2IConverter.cs
├── Assets/
|   ├── FengShuiCollection/
|   |   └── ...
|   ├── SeasonCollection/
|   |   └── ...
|   └── ...
├── IDao/
|   ├── IDao.cs
|   └── MockDao.cs
├── Model/
|   ├── Blog.cs
|   ├── GroupCollection.cs
|   ├── Message.cs
|   ├── MyShoppingItem.cs
|   ├── PageChanger.cs
|   ├── Product.cs
|   └── Reviews.cs
├── View/
|   ├── MainView.xaml/
|   |   └── MainView.xaml.cs
|   |   .../
|   |   └── ...   
├── ViewModel/
|   └── BlogViewModel.cs
|   └── GroupCollectionViewModel.cs
|   └── MainViewViewModel.cs
|   └── MessageViewModel.cs
|   └── ShopListViewModel.cs
├── App.xaml/
|   └── App.xaml.cs
├── MainWindow.xaml/
|   └── ...
└── FodyWeavers.xaml/
    └── ...
```
## 3.Xây dựng
### 4.1 Quy định
- Branch **main** là branch chinshm là phiên bản ổn định trước khi cập nhật của toàn dự án.
- Branch **develop** sẽ là branch mà các thành viên tạo **pull request** từ branch của mình để gộp code.
- Mỗi tính năng sẽ là 1 branch
### 4.2 Quy trình
- Tạo branch mới với tên branch là tính năng mình sẽ làm, với base là branch **develop**.
- Clone branch của mình về và làm.
- Sau khi làm xong thì tiến hành **push** lên Github.
- Tạo **Pull request** compare giữa branch của mình và branch **develop**.


## 4.Thành viên
### **Team Leader**
- <https://github.com/nayud21> #22120001
### **Team Member**
- <https://github.com/Dien2112> #22120062
- <https://github.com/farmcreepissohard> #22120067


# Milestone 1 - Phần mềm Desktop hỗ trợ bán cây cảnh cho cửa hàng nhỏ
-**Ngày bắt đầu**:3/10
-**Ngày kết thúc**:30/10
## 1. Chức năng đã hoàn thành
| Chức năng                   | Mô tả                                                                    | Thời gian thực hiện       | Điểm tự đánh giá |
|-----------------------------|----------------------------------------------                            |----------------------     |------------------|
| Mua bán cung cấp sản phẩm   | Cung cấp sản phẩm, mua bán cho khách hàng từ cây cảnh đến các thiết bị đi kèm      | 2.75/3 giờ      | 9.75/10             |
| Giỏ hàng                    | Thêm sản phẩm dự định mua vào mục ”giỏ hàng” để có thể thanh toán        | 1.75/2 giờ                | 9.75/10             |
| Bộ sưu tập                  | Bộ sưu tập (category) theo mùa, địa điểm, phong thủy                     | 2.75/3 giờ                | 9.75/10             |
| Blog về sản phẩm/ Diễn đàn câu hỏi  | Cung cấp diễn đàn cho phép người dùng viết cái blog về sản phẩm hoặc đặt câu hỏi  | 2.75/3 giờ | 9.75/10             |
| Liên hệ trực tiếp qua ứng dụng          | Cho phép người mua và người bán trao đổi trực tiếp trên ứng dụng | 1.75/2 giờ             | 9.75/10             |
## 2. Hướng dẫn sử dụng
### 2.1 Mua bán cung cấp sản phẩm
- Khi người dùng chạy chương trình, ứng dụng sẽ hiển thị các sản phẩm được bán, khi nào cần thanh toán mới cần đăng nhập (tính năng đăng nhập sẽ phát triển sau).
- Người dùng có thể click vào hình ảnh của sản phẩm để biết thêm thông thông tin chi tiết về sản phẩm
- Người dùng rê chuột vào hình ảnh của sản phẩm thì sẽ xuất hiện hình ảnh khác của sản phẩm và tên khác.
### 2.2 Giỏ hàng
- Ở trang mặc định, khi người dùng click vào icon giỏ hàng trên sản phẩm, hệ thống sẽ cập nhật sản phẩm vào trang **Giỏ hàng**, mỗi lần click là thêm vào giỏ 1 sản phẩm
- Khách hàng cũng có thể thêm sản phẩm vào **Giỏ hàng** ở trang chi tiết của sản phẩm, cũng có thể thêm vào giỏ hàng với số lượng mong muốn
- Khi click vào button **Giỏ hàng** trên thanh điều hướng, ứng dụng sẽ chuyển đến màn hình **Giỏ hàng**. Tại đó sẽ hiển thị thông tin về các sản phẩm đã được thêm vào trước đó.
- Người dùng có thể xóa các sản phẩm mà mình đã thêm vào cũng như tăng số lượng sản phẩm.
- Người dùng có thể chỉ định những sản phẩm mà mình muốn thanh toán trong cửa hàng.
- Vì hiện tại chưa phát triển tính năng đăng nhập để phân quyền nên button mua sẽ chưa thực hiện được
### 2.3 Bộ sưu tập
- Người dùng sẽ click vào button **Collection** trên tranh điều hướng để chuyển đến trang **Collection**
- Tại đó sẽ xuất hiện các bộ sưu tập theo mùa/ phong thủy.
- Khi người dùng click vào biểu tượng dưới góc phải cùng của từng **Collection** sẽ xuất hiện các hình ảnh của cây thuộc **Collection** đó
### 2.4 Blog
- Người dùng sẽ click vào button **Blog** trên thanh điều hướng để chuyển đến trang **Blog**
- Tại đây sẽ xuất hiện 1 loạt các blog đã được đăng trước đó.
- Người dùng cũng có thể đăng bài của chính mình bằng cách click vào buttn **Đăng bài**
- Form để đăng bài sẽ hiện ra
- Vì ở đây vẫn còn dùng Mock Data nên tạm thời tính năng gửi bài chưa thực hiện.
- Ở mỗi trang sẽ có button **Quay lại** để người dùng có thể quay lại trang trước đó.
### 2.5 Trò chuyện trực tiếp với người dùng
- Người dùng click vào button **Chat** trên thanh điều hướng để chuyển đến trang **Chat**
- Tại đó sẽ xuất hiện cửa sổ gồm những người đã gửi tin nhắn cho người chủ
- Click vào khung của từng khách hàng để xem nội dung tin nhắn
- Vì ở đây còn sử dụng MockData nên tính năng gửi tạm thời chưa thực hiện được
## 3. Đánh giá tổng quan và nhận xét
**Tổng số giờ**: 11.75 giờ
**Tổng điểm tự đánh giá**: 9.75 điểm
**Ưu điểm**: Chịu khó tìm hiểu, kiên trì trong công việc.
**Khó khăn**:Do mới bắt đầu nên các quá trình thực thi chức năng, cũng như quá trình làm việc còn nhiều thiếu sót.

