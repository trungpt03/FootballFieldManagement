   M S B A M L   `   `   `  ����   QuanLySanBong&     QuanLySanBong.Views.DatSanCoDinh   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Đặt Sân Cố Định��$	��350��$	��600�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � ColumnDefinitions �� $	��93* ��� $
��197* � � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Đặt Sân Cố Định��$��20(�$
��Bold"�$
��Left=�$��	27,0,0,10q�$��0��$��1���� $��1��$��	30,10,0,0q�$	��Top=�$
��Left=�$��2��.+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��Ngày Bắt Đầu:��$��Center=�$	��100��(  "System.Windows.Controls.DatePicker  -     Name$ dpBatDau��$	��150��$��Center=��� $��Ngày Kết Thúc:��$��Center=�$��20,0,0,0q�$	��100��  -   $ 	dpKetThuc��$	��150��$��Center=�� .+��� $ 
Horizontal=�$��0,0,0,10q�.+��� $��Sân:��$��Center=�$	��100���� -    ��Name$ cbSan��$	��150�� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ 	StadiumID��$��22��$��Center=��� $ 
Horizontal=�$��	20,0,0,10q�.+��� $��Chọn Thứ:��$��Center=�$	��100���� -   $ cbThu��$	��150��$��22��	 �� 
IsEditable$	 False��
 �� 
IsReadOnly$

 True��$��Center=�.@��� $��	Thứ hai���� $��Thứ ba���� $��	Thứ tư���� $��
Thứ năm���� $��
Thứ sáu���� $��Thứ bảy���� $��Chủ nhật���� $ 
Horizontal=�$��0,0,0,10q�.+��� $��Giờ Bắt Đầu:��$��Center=�$	��100���� -   $ cbGioBatDau��$	��150��$��22��$��Center=��� $��Giờ Kết Thúc:��$��Center=�$��20,0,0,0q�$	��100���� -   $ cbGioKetThuc��$	��150��$��22��$��Center=��� $ 
Horizontal=�$��0,0,0,10q�.+��� $��Tên Khách Hàng:��$��Center=�$	��100���� -    ��Name$ txtTenKhachHang��$	��300��$��20��$��Segoe UI)�$��Center=��� $ 
Horizontal=�$��0,0,0,10q�.+��� $��Số Điện Thoại:��$��Center=�$	��100���� -   $ txtSoDienThoai��$	��300��$��20��$��Segoe UI)�$��Center=��� $ 
Horizontal=�$��20,5,0,0q�.+��� -	    ��Name$ 	cbIsMatch��$��Đã có đối?��$��Center=��� $ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -
    ��Name$ 	btnDatSan��$��Đặt Sân��$	��100��$��30��$��0,0,20,0q��� -   $ btnHuy��$��Hủy��$	��100��$��30��