   M S B A M L   `   `   `  ���� H  DQuanLySanBong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLySanBong.ViewsQuanLySanBong.Views       QuanLySanBong.Views.HoaDon   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:QuanLySanBong.Views       � Title$  
Hóa đơn��$	��450��$	��600�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $��* ��� $��* �.+��� $��10q�$	��Top=�$��0��.+��� $��Thông tin hóa đơn��$
��Bold"�$��16(�$��Center=�$��0,0,0,10q�� $	��0,5q�.+��� $��Giờ vào:��$	��120��$��Center=��� -   $��StartTimeText��$	��120��$��Center=�� $	��0,5q�.+��� $��	Giờ ra:��$	��120��$��Center=��� -   $��EndTimeText��$	��120��$��Center=�� $	��0,5q�.+��� $��Tổng giờ sử dụng:��$	��120��$��Center=��� -   $��TotalHoursText��$	��120��$��Center=�� $	��0,5q�.+��� $��Tiền dịch vụ:��$	��120��$��Center=��� -   $��
DichVuText��$	��120��$��Center=�� $	��0,5q�.+��� $��Tiền sân:��$	��120��$��Center=��� -   $��TienSanTextBox��$��25��$��1q��� 	.000VND� $	��0,5q�.+��� $��Giảm giá:��$	��120��$��Center=��� -   $��GiamGiaTextBox��$��0��$��25���� 	.000VND� $	��0,5q�.+��� $��Tổng tiền (VND):��$	��120��$��Center=��� -   $��TongTienText��$	��120��$��Center=�$
��Bold"�$��14(�
���  ���� $	��0,5q�.+��� $��	Ghi chú:��$	��120��$
��Left=��� -    ��Name$ 	txtGhiChu��$	��200��$��Center=�$
��Left=�$��60�� �� TextWrapping$
 Wrap=�$��Segoe UI)�� $��Center=�$
��0,20q�.+��� -	    ��Name$ ConfirmButton��$��Xác nhận��$	��100��$��5q��� -
   $��Hủy��$	��100��$��5q�&   System.Windows.Controls.DataGrid  -     Name$ dgDichVu��   AutoGenerateColumns$ False��$��1��$��10q�   
IsReadOnly$
 True��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Tên Sản Phẩm��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ProductName+  $
 SL��$ 40  �� *
Quantity+  $
 Tổng Tiền��$ 80  �� *
TotalPrice+ �� StringFormat$ N0��