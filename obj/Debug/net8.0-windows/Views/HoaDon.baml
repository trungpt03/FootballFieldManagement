   M S B A M L   `   `   `  ����H  DQuanLySanBong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLySanBong.ViewsQuanLySanBong.Views  5   	        QuanLySanBong.Views.HoaDon   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:QuanLySanBong.Views     5   	     � Title$  
Hóa đơn��5   	   $	��450��6   $	��600��6&    � WindowStartupLocation$ CenterScreen=�62   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��10q�6   $	��Top=�6!   $��0��69   .+�5      �� $��Thông tin hóa đơn��6   $
��Bold"�61   $��16(�6C   $��Center=�6Q   $��0,0,0,10q�6n   � 5      $	��0,5q�6   .+�5      �� $��Giờ vào:��6   $	��120��6,   $��Center=�68   �� 5      -   5        $��StartTimeText��5      $	��120��61   $��Center=�6=   5      � 5      $	��0,5q�6   .+�5      �� $��	Giờ ra:��6   $	��120��6+   $��Center=�67   �� 5      -   5        $��EndTimeText��5      $	��120��6/   $��Center=�6;   5      � 5      $	��0,5q�6   .+�5       �� $��Tổng giờ sử dụng:��6   $	��120��65   $��Center=�6A   �� 5!      -   5        $��TotalHoursText��5!      $	��120��62   $��Center=�6>   5"      � 5$      $	��0,5q�6   .+�5%      �� $��Tiền dịch vụ:��6   $	��120��61   $��Center=�6=   �� 5&      -   5        $��
DichVuText��5&      $	��120��6.   $��Center=�6:   5'      � 5*      $	��0,5q�6   .+�5+      �� $��Tiền sân:��6   $	��120��6-   $��Center=�69   �� 5,      -   5        $��TienSanTextBox��5,      $��25��60   $��1q�6d   �� 5-      	.000VND6%   5.      � 51      $	��0,5q�6   .+�52      �� $��Giảm giá:��6   $	��120��6-   $��Center=�69   �� 53      -   5        $��GiamGiaTextBox��53      $��0��60   $��25��69   6D   �� 54      	.000VND6%   55      � 58      $	��0,5q�6   .+�59      �� $��Tổng tiền (VND):��6   $	��120��64   $��Center=�6@   �� 5:      -   5        $��TongTienText��5:      $	��120��60   $��Center=�6<   $
��Bold"�6W   $��14(�6i   
���  ��6w   5;      �� 5=      $	��0,5q�6   .+�5>      �� $��	Ghi chú:��6   $	��120��6,   $
��Left=�68   �� 5?      -   5         ��Name$ 	txtGhiChu��5?      $	��200��6-   $��Center=�69   $
��Left=�6T   $��60��6o    �� TextWrapping$
 Wrap=�6{   $��Segoe UI)�6�   5@      � 5C      $��Center=�6   $
��0,20q�65   .+�5D      �� -	   5         ��Name$ ConfirmButton��5D      $��Xác nhận��60   $	��100��6C   $��5q�6O   6Z   �� 5E      -
   5        $��Hủy��5E      $	��100��6'   $��5q�63   6>   5F      5H      &   System.Windows.Controls.DataGrid  5J   
   -   5          Name$ dgDichVu��5J         AutoGenerateColumns$ False��6%   $��1��6A   $��10q�6Q      
IsReadOnly$
 True��6]   	   Columns	 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Tên Sản Phẩm��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ProductName+6[     5M      $
 SL��6%   $ 40 6N    61   �� *
Quantity+6N     5N      $
 Tổng Tiền��6%   $ 80 6h    68   �� *
TotalPrice+ �� StringFormat$ N0��6h   5P      5Q      5R      